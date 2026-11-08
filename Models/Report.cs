using System.Globalization;
using System.Text;
using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public interface IReportable
{
    string ReportTitle { get; }
    DataTable GetOrders();
    void ExportCsv(string path);
}

public abstract class Report : IReportable
{
    protected Report(DateTime start, DateTime endExclusive)
    {
        Start = start;
        End = endExclusive;
        GeneratedBy = Session.FullName;
        DateGenerated = DateTime.Now;
    }

    public DateTime Start { get; }
    public DateTime End { get; }          // exclusive
    public string GeneratedBy { get; }
    public DateTime DateGenerated { get; }
    public abstract string ReportTitle { get; }

    public DataTable GetOrders() => GetData(
        "SELECT o.OrderID, o.OrderDate, u.FullName AS Cashier, o.Subtotal, o.Discount, " +
        "o.TotalAmount, o.PaymentMethod, o.OrderStatus " +
        "FROM Orders AS o LEFT JOIN Users AS u ON o.UserID = u.UserID " +
        "WHERE o.OrderDate >= ? AND o.OrderDate < ? ORDER BY o.OrderID",
        P(Start), P(End));

    public decimal CalculateTotalRevenue() => Convert.ToDecimal(ExecuteScalar(
        "SELECT SUM(TotalAmount) FROM Orders WHERE OrderStatus = 'Completed' AND OrderDate >= ? AND OrderDate < ?",
        P(Start), P(End)) ?? 0m);

    public int CountOrders() => Convert.ToInt32(ExecuteScalar(
        "SELECT COUNT(*) FROM Orders WHERE OrderStatus = 'Completed' AND OrderDate >= ? AND OrderDate < ?",
        P(Start), P(End)));

    public void ExportCsv(string path)
    {
        DataTable table = GetOrders();
        var sb = new StringBuilder();
        sb.AppendLine(string.Join(",", table.Columns.Cast<DataColumn>().Select(c => Quote(c.ColumnName))));
        foreach (DataRow row in table.Rows)
            sb.AppendLine(string.Join(",", row.ItemArray.Select(Quote)));
        File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));   // BOM so Excel reads it correctly
    }

    private static string Quote(object? value)
    {
        string s = value is DateTime d
            ? d.ToString("yyyy-MM-dd HH:mm")
            : Convert.ToString(value, CultureInfo.InvariantCulture) ?? "";
        return "\"" + s.Replace("\"", "\"\"") + "\"";
    }
}

public class DailyReport : Report
{
    public DailyReport(DateTime day) : base(day.Date, day.Date.AddDays(1)) { }
    public override string ReportTitle => $"Daily Sales Report - {Start:yyyy-MM-dd}";
}

public class WeeklyReport : Report
{
    public WeeklyReport(DateTime anyDayInWeek) : base(MondayOf(anyDayInWeek), MondayOf(anyDayInWeek).AddDays(7)) { }

    private static DateTime MondayOf(DateTime d) =>
        d.Date.AddDays(-((7 + (int)d.DayOfWeek - (int)DayOfWeek.Monday) % 7));

    public override string ReportTitle =>
        $"Weekly Sales Report - {Start:yyyy-MM-dd} to {End.AddDays(-1):yyyy-MM-dd}";
}