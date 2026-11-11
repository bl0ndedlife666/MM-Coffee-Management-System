using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class MainDashboard : Form
{

    public MainDashboard()
    {
        InitializeComponent();
        Load += (s, e) => Setup();

        btnNewOrder.Click += (s, e) => { using var f = new OrderForm(); f.ShowDialog(); RefreshDashboard(); };
        btnMenu.Click += (s, e) => { using var f = new MenuManagementForm(); f.ShowDialog(); };
        btnInventory.Click += (s, e) => { using var f = new InventoryForm(); f.ShowDialog(); RefreshDashboard(); };
        btnSuppliers.Click += (s, e) => { using var f = new SupplierForm(); f.ShowDialog(); };
        btnStaff.Click += (s, e) => { using var f = new StaffForm(); f.ShowDialog(); };
        btnReports.Click += (s, e) => { using var f = new ReportsForm(); f.ShowDialog(); };
        btnAnalytics.Click += (s, e) => { using var f = new AnalyticsForm(); f.ShowDialog(); };
        btnHistory.Click += (s, e) => { using var f = new OrderHistoryForm(); f.ShowDialog(); };
        btnVoid.Click += btnVoid_Click;
        btnLogout.Click += (s, e) => { Session.Clear(); Close(); };
        FormClosing += (s, e) => BackupService.Run();   // automatic backup on logout or close
        btnBackup.Click += (s, e) =>
        {
            string? path = BackupService.Run();
            MessageBox.Show(path != null ? "Backup saved:\n" + path
                                         : "Backup failed. Close anything using the database and try again.");
        };
    }

    private void Setup()
    {
        lblWelcome.Text = $"Welcome, {Session.FullName} ({Session.Role})";

        // Cashiers only see Order and Inventory (read-only) and Log out
        bool admin = Session.IsAdmin;
        btnMenu.Visible = btnSuppliers.Visible = btnStaff.Visible =
            btnReports.Visible = btnAnalytics.Visible = admin;
        btnBackup.Visible = admin;
        RefreshDashboard();
    }

    private void RefreshDashboard()
    {
        var low = GetData(
            "SELECT IngredientName AS Ingredient, QuantityOnHand AS [On Hand], " +
            "ReorderLevel AS [Reorder At], UnitName AS Unit " +
            "FROM Ingredients WHERE QuantityOnHand <= ReorderLevel ORDER BY IngredientName");
        dgvLowStock.DataSource = low;

        DateTime start = DateTime.Today, end = start.AddDays(1);
        var today = GetData(
            "SELECT OrderID, OrderDate, TotalAmount FROM Orders " +
            "WHERE OrderStatus = 'Completed' AND OrderDate >= ? AND OrderDate < ? ORDER BY OrderID DESC",
            P(start), P(end));
        dgvToday.DataSource = today;

        decimal sum = today.AsEnumerable().Sum(r => Convert.ToDecimal(r["TotalAmount"]));
        lblTodaySales.Text = $"Today's sales: {sum:N2}  ({today.Rows.Count} orders)";

        // KPI cards
        lblKpiSales.Text = sum.ToString("N2");
        lblKpiOrders.Text = today.Rows.Count.ToString();
        lblKpiLow.Text = low.Rows.Count.ToString();
        lblKpiLow.ForeColor = low.Rows.Count > 0 ? Color.OrangeRed : Color.LightGreen;

        // Grid formatting
        dgvToday.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
        dgvToday.Columns["OrderDate"].DefaultCellStyle.Format = "hh:mm tt";
    }

    private void btnVoid_Click(object? sender, EventArgs e)
    {
        if (dgvToday.CurrentRow == null)
        {
            MessageBox.Show("Select an order to void.");
            return;
        }
        int id = Convert.ToInt32(dgvToday.CurrentRow.Cells["OrderID"].Value);
        if (MessageBox.Show($"Void order #{id}? Ingredient stock will be restored.", "Confirm void",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
        try
        {
            OrderService.VoidOrder(id);
            RefreshDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not void order: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {

    }
}