namespace CoffeeManagementSystem;

public partial class ReportsForm : Form
{
    private Report? _current;

    public ReportsForm()
    {
        InitializeComponent();
        Load += (s, e) =>
        {
            cboType.Items.AddRange(new object[] { "Daily", "Weekly" });
            cboType.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
            Generate();
        };
        btnGenerate.Click += (s, e) => Generate();
        btnExport.Click += btnExport_Click;
    }

    private void Generate()
    {
        try
        {
            Report r = cboType.Text == "Weekly" ? new WeeklyReport(dtpDate.Value) : new DailyReport(dtpDate.Value);
            _current = r;
            dgvReport.DataSource = r.GetOrders();

            int count = r.CountOrders();
            decimal revenue = r.CalculateTotalRevenue();
            decimal avg = count > 0 ? revenue / count : 0m;
            lblSummary.Text = $"{r.ReportTitle}\nCompleted orders: {count}    Revenue: {revenue:N2}    Average order: {avg:N2}";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not generate the report: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnExport_Click(object? sender, EventArgs e)
    {
        if (_current == null) { MessageBox.Show("Generate a report first."); return; }

        using var dlg = new SaveFileDialog
        {
            Filter = "CSV file (*.csv)|*.csv",
            FileName = $"{cboType.Text}-report-{_current.Start:yyyyMMdd}.csv"
        };
        if (dlg.ShowDialog() != DialogResult.OK) return;

        try
        {
            _current.ExportCsv(dlg.FileName);
            MessageBox.Show("Report exported.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}