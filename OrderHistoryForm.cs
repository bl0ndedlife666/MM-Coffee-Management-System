using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class OrderHistoryForm : Form
{
    public OrderHistoryForm()
    {
        InitializeComponent();
        Load += (s, e) => Search();
        btnSearch.Click += (s, e) => Search();
        dgvOrders.SelectionChanged += (s, e) => ShowLines();
        btnReprint.Click += btnReprint_Click;
    }

    private void Search()
    {
        string sql =
            "SELECT o.OrderID, o.OrderDate, u.FullName AS Cashier, o.OrderType AS [Type], " +
            "o.CustomerName AS [Customer], o.TotalAmount AS Total, o.PaymentMethod AS Payment, o.OrderStatus AS [Status] " +
            "FROM Orders AS o LEFT JOIN Users AS u ON o.UserID = u.UserID WHERE 1 = 1";
        var ps = new List<OleDbParameter>();

        // Cashiers can only see today's orders
        if (!Session.IsAdmin) { sql += " AND o.OrderDate >= ?"; ps.Add(P(DateTime.Today)); }

        if (int.TryParse(txtOrderNo.Text, out int no))
        {
            sql += " AND o.OrderID = ?";
            ps.Add(P(no));
        }
        else if (chkByDate.Checked)
        {
            sql += " AND o.OrderDate >= ? AND o.OrderDate < ?";
            ps.Add(P(dtpDate.Value.Date));
            ps.Add(P(dtpDate.Value.Date.AddDays(1)));
        }
        sql += " ORDER BY o.OrderID DESC";

        dgvOrders.DataSource = GetData(sql, ps.ToArray());
        dgvOrders.Columns["Total"].DefaultCellStyle.Format = "N2";
        dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm tt";
        ShowLines();
    }

    private void ShowLines()
    {
        if (dgvOrders.CurrentRow == null || !dgvOrders.Columns.Contains("OrderID")) { dgvLines.DataSource = null; return; }
        object? id = dgvOrders.CurrentRow.Cells["OrderID"].Value;
        if (id is null or DBNull) { dgvLines.DataSource = null; return; }

        dgvLines.DataSource = GetData(
            "SELECT m.ItemName AS Item, oi.SizeName AS [Size], oi.Quantity AS Qty, oi.UnitPrice AS [Unit price] " +
            "FROM OrderItems AS oi INNER JOIN MenuItems AS m ON oi.ItemID = m.ItemID WHERE oi.OrderID = ?",
            P(Convert.ToInt32(id)));
    }

    private void btnReprint_Click(object? sender, EventArgs e)
    {
        object? id = dgvOrders.CurrentRow?.Cells["OrderID"].Value;
        if (id is null or DBNull)
        {
            MessageBox.Show("Select an order first.");
            return;
        }
        ReceiptPrinter.Show(Convert.ToInt32(id), reprint: true);
    }
}