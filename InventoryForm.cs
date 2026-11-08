using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class InventoryForm : Form
{
    public InventoryForm()
    {
        InitializeComponent();
        Load += (s, e) => Init();
        dgvStock.DataBindingComplete += (s, e) => Highlight();
        btnAddIngredient.Click += btnAddIngredient_Click;
        btnStockIn.Click += btnStockIn_Click;
    }

    private void Init()
    {
        pnlAdmin.Visible = Session.IsAdmin;
        LoadLookups();
        LoadStock();
    }

    private void LoadLookups()
    {
        var sup = GetData("SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName");
        var none = sup.NewRow();
        none["SupplierID"] = 0;
        none["SupplierName"] = "(none)";
        sup.Rows.InsertAt(none, 0);
        cboSupplier.DisplayMember = "SupplierName";
        cboSupplier.ValueMember = "SupplierID";
        cboSupplier.DataSource = sup;

        cboIngredient.DisplayMember = "IngredientName";
        cboIngredient.ValueMember = "IngredientID";
        cboIngredient.DataSource = GetData("SELECT IngredientID, IngredientName FROM Ingredients ORDER BY IngredientName");
    }

    private void LoadStock()
    {
        dgvStock.DataSource = GetData(
            "SELECT g.IngredientID, g.IngredientName AS [Ingredient], g.QuantityOnHand AS [On Hand], " +
            "g.UnitName AS [Unit], g.ReorderLevel AS [Reorder At], s.SupplierName AS [Supplier] " +
            "FROM Ingredients AS g LEFT JOIN Suppliers AS s ON g.SupplierID = s.SupplierID " +
            "ORDER BY g.IngredientName");
        dgvStock.Columns["IngredientID"].Visible = false;
    }

    // Rows at or below the reorder level are tinted red
    private void Highlight()
    {
        foreach (DataGridViewRow row in dgvStock.Rows)
        {
            if (row.Cells["On Hand"].Value is double have && row.Cells["Reorder At"].Value is double min && have <= min)
                row.DefaultCellStyle.BackColor = Color.MistyRose;
        }
    }

    private void btnAddIngredient_Click(object? sender, EventArgs e)
    {
        string name = txtIngName.Text.Trim();
        string unit = txtUnit.Text.Trim();
        if (name == "" || unit == "") { MessageBox.Show("Enter the ingredient name and unit."); return; }
        if (!double.TryParse(txtReorder.Text, out var reorder) || reorder < 0)
        { MessageBox.Show("Enter a valid reorder level."); return; }

        int sup = Convert.ToInt32(cboSupplier.SelectedValue);
        try
        {
            ExecuteNonQuery(
                "INSERT INTO Ingredients (IngredientName, UnitName, QuantityOnHand, ReorderLevel, SupplierID) VALUES (?, ?, 0, ?, ?)",
                P(name), P(unit), P(reorder), P(sup == 0 ? (int?)null : sup));
            txtIngName.Clear(); txtUnit.Clear(); txtReorder.Clear();
            LoadLookups();
            LoadStock();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not add ingredient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnStockIn_Click(object? sender, EventArgs e)
    {
        if (cboIngredient.SelectedValue == null) return;
        if (!double.TryParse(txtQty.Text, out var qty) || qty <= 0)
        { MessageBox.Show("Enter a quantity greater than zero."); return; }
        if (!decimal.TryParse(txtUnitCost.Text, out var cost) || cost < 0)
        { MessageBox.Show("Enter a valid unit cost."); return; }

        int ing = Convert.ToInt32(cboIngredient.SelectedValue);
        int sup = Convert.ToInt32(cboSupplier.SelectedValue);

        try
        {
            using var conn = new OleDbConnection(ConnectionString);
            conn.Open();
            using var tx = conn.BeginTransaction();
            try
            {
                using (var c1 = new OleDbCommand(
                    "INSERT INTO StockIns (IngredientID, SupplierID, Quantity, UnitCost, DateReceived) VALUES (?, ?, ?, ?, ?)",
                    conn, tx))
                {
                    c1.Parameters.AddRange(new[]
                    {
                        P(ing), P(sup == 0 ? (int?)null : sup), P(qty), P(cost), P(DateTime.Now)
                    });
                    c1.ExecuteNonQuery();
                }
                using (var c2 = new OleDbCommand(
                    "UPDATE Ingredients SET QuantityOnHand = QuantityOnHand + ? WHERE IngredientID = ?", conn, tx))
                {
                    c2.Parameters.AddRange(new[] { P(qty), P(ing) });
                    c2.ExecuteNonQuery();
                }
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }

            txtQty.Clear(); txtUnitCost.Clear();
            LoadStock();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not record delivery: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
