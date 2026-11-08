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
        btnVoid.Click += btnVoid_Click;
        btnLogout.Click += (s, e) => { Session.Clear(); Close(); };
    }

    private void Setup()
    {
        lblWelcome.Text = $"Welcome, {Session.FullName} ({Session.Role})";

        // Cashiers only see Order and Inventory (read-only) and Log out
        bool admin = Session.IsAdmin;
        btnMenu.Visible = btnSuppliers.Visible = btnStaff.Visible =
            btnReports.Visible = btnAnalytics.Visible = admin;

        RefreshDashboard();
    }

    private void RefreshDashboard()
    {
        dgvLowStock.DataSource = GetData(
            "SELECT IngredientName AS Ingredient, QuantityOnHand AS [On Hand], " +
            "ReorderLevel AS [Reorder At], UnitName AS Unit " +
            "FROM Ingredients WHERE QuantityOnHand <= ReorderLevel ORDER BY IngredientName");

        DateTime start = DateTime.Today, end = start.AddDays(1);
        var today = GetData(
            "SELECT OrderID, OrderDate, TotalAmount FROM Orders " +
            "WHERE OrderStatus = 'Completed' AND OrderDate >= ? AND OrderDate < ? ORDER BY OrderID DESC",
            P(start), P(end));
        dgvToday.DataSource = today;

        decimal sum = today.AsEnumerable().Sum(r => Convert.ToDecimal(r["TotalAmount"]));
        lblTodaySales.Text = $"Today's sales: {sum:N2}  ({today.Rows.Count} orders)";
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