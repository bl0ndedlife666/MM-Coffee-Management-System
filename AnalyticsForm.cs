using System.Windows.Forms.DataVisualization.Charting;
using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class AnalyticsForm : Form
{
    private readonly Chart _hourly, _daily, _top, _pay;

    public AnalyticsForm()
    {
        InitializeComponent();

        _hourly = MakeChart("Orders per hour of day", SeriesChartType.Column);
        _daily = MakeChart("Revenue per day", SeriesChartType.Line);
        _top = MakeChart("Top 5 items (units sold)", SeriesChartType.Bar);
        _pay = MakeChart("Revenue by payment method", SeriesChartType.Pie);

        tlpCharts.Controls.Add(_hourly, 0, 0);
        tlpCharts.Controls.Add(_daily, 1, 0);
        tlpCharts.Controls.Add(_top, 0, 1);
        tlpCharts.Controls.Add(_pay, 1, 1);

        cboPeriod.SelectedIndexChanged += (s, e) => RefreshAll();
        Load += (s, e) =>
        {
            cboPeriod.Items.AddRange(new object[] { "Last 7 days", "Last 30 days", "All time" });
            cboPeriod.SelectedIndex = 0;   // triggers RefreshAll
        };
    }

    private static Chart MakeChart(string title, SeriesChartType type)
    {
        var chart = new Chart { Dock = DockStyle.Fill };
        chart.ChartAreas.Add(new ChartArea("main"));
        chart.Titles.Add(title);
        chart.Series.Add(new Series("data") { ChartType = type, IsValueShownAsLabel = true });
        return chart;
    }

    private DateTime GetStart() => cboPeriod.SelectedIndex switch
    {
        0 => DateTime.Today.AddDays(-6),
        1 => DateTime.Today.AddDays(-29),
        _ => new DateTime(2000, 1, 1)
    };

    private static void Fill(Chart chart, IEnumerable<(string Label, double Value)> points)
    {
        var s = chart.Series["data"];
        s.Points.Clear();
        foreach (var (label, value) in points) s.Points.AddXY(label, value);
    }

    private void RefreshAll()
    {
        if (cboPeriod.SelectedIndex < 0) return;
        DateTime from = GetStart();

        try
        {
            // KPIs
            decimal revenue = Convert.ToDecimal(ExecuteScalar(
                "SELECT SUM(TotalAmount) FROM Orders WHERE OrderStatus = 'Completed' AND OrderDate >= ?", P(from)) ?? 0m);
            int orders = Convert.ToInt32(ExecuteScalar(
                "SELECT COUNT(*) FROM Orders WHERE OrderStatus = 'Completed' AND OrderDate >= ?", P(from)));
            lblRevenue.Text = $"Revenue: {revenue:N2}";
            lblOrders.Text = $"Orders: {orders}";
            lblAvg.Text = $"Average order: {(orders > 0 ? revenue / orders : 0m):N2}";

            // Orders per hour (peak hour)
            var hours = GetData(
                "SELECT Hour(OrderDate) AS H, COUNT(*) AS N FROM Orders " +
                "WHERE OrderStatus = 'Completed' AND OrderDate >= ? GROUP BY Hour(OrderDate) ORDER BY Hour(OrderDate)",
                P(from));
            Fill(_hourly, hours.AsEnumerable().Select(r => ($"{Convert.ToInt32(r["H"])}:00", Convert.ToDouble(r["N"]))));
            lblPeak.Text = hours.Rows.Count == 0
                ? "Peak hour: -"
                : $"Peak hour: {Convert.ToInt32(hours.AsEnumerable().OrderByDescending(r => Convert.ToInt32(r["N"])).First()["H"])}:00";

            // Revenue per day (trend)
            var days = GetData(
                "SELECT Int(OrderDate) AS D, SUM(TotalAmount) AS Rev FROM Orders " +
                "WHERE OrderStatus = 'Completed' AND OrderDate >= ? GROUP BY Int(OrderDate) ORDER BY Int(OrderDate)",
                P(from));
            Fill(_daily, days.AsEnumerable().Select(r =>
            {
                DateTime day = r["D"] is DateTime d ? d : DateTime.FromOADate(Convert.ToDouble(r["D"]));
                return (day.ToString("MMM dd"), Convert.ToDouble(r["Rev"]));
            }));

            // Top 5 items
            var top = GetData(
                "SELECT TOP 5 m.ItemName, SUM(oi.Quantity) AS Units " +
                "FROM (OrderItems AS oi INNER JOIN MenuItems AS m ON oi.ItemID = m.ItemID) " +
                "INNER JOIN Orders AS o ON oi.OrderID = o.OrderID " +
                "WHERE o.OrderStatus = 'Completed' AND o.OrderDate >= ? " +
                "GROUP BY m.ItemName ORDER BY SUM(oi.Quantity) DESC", P(from));
            Fill(_top, top.AsEnumerable().Select(r => (r["ItemName"].ToString()!, Convert.ToDouble(r["Units"]))));

            // Revenue by payment method
            var pay = GetData(
                "SELECT PaymentMethod, SUM(TotalAmount) AS Rev FROM Orders " +
                "WHERE OrderStatus = 'Completed' AND OrderDate >= ? GROUP BY PaymentMethod", P(from));
            Fill(_pay, pay.AsEnumerable().Select(r => (r["PaymentMethod"].ToString()!, Convert.ToDouble(r["Rev"]))));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not load analytics: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}