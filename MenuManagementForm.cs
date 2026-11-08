using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class MenuManagementForm : Form
{
    private int _selectedId = 0;

    public MenuManagementForm()
    {
        InitializeComponent();
        Load += (s, e) => Init();
        dgvItems.SelectionChanged += (s, e) => FillFromGrid();
        btnNew.Click += (s, e) => ClearForm();
        btnSave.Click += btnSave_Click;
        btnAddIngredient.Click += btnAddIngredient_Click;
        btnRemoveIngredient.Click += btnRemoveIngredient_Click;
    }

    private void Init()
    {
        cboCategory.DisplayMember = "CategoryName";
        cboCategory.ValueMember = "CategoryID";
        cboCategory.DataSource = GetData("SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName");

        cboIngredient.DisplayMember = "IngredientName";
        cboIngredient.ValueMember = "IngredientID";
        cboIngredient.DataSource = GetData("SELECT IngredientID, IngredientName FROM Ingredients ORDER BY IngredientName");

        LoadItems();
    }

    private void LoadItems()
    {
        dgvItems.DataSource = GetData(
            "SELECT m.ItemID, m.CategoryID, m.ItemName AS [Item], c.CategoryName AS [Category], " +
            "m.BasePrice AS [Price], m.IsActive AS [Active] " +
            "FROM MenuItems AS m LEFT JOIN Categories AS c ON m.CategoryID = c.CategoryID " +
            "ORDER BY c.CategoryName, m.ItemName");
        dgvItems.Columns["ItemID"].Visible = false;
        dgvItems.Columns["CategoryID"].Visible = false;
    }

    private void FillFromGrid()
    {
        if (dgvItems.CurrentRow == null || !dgvItems.Columns.Contains("ItemID")) return;
        var c = dgvItems.CurrentRow.Cells;
        _selectedId = Convert.ToInt32(c["ItemID"].Value);
        txtName.Text = c["Item"].Value?.ToString();
        if (c["CategoryID"].Value != DBNull.Value)
            cboCategory.SelectedValue = Convert.ToInt32(c["CategoryID"].Value);
        txtPrice.Text = Convert.ToDecimal(c["Price"].Value).ToString("0.00");
        chkActive.Checked = Convert.ToBoolean(c["Active"].Value);
        LoadRecipe();
    }

    private void ClearForm()
    {
        _selectedId = 0;
        txtName.Clear();
        txtPrice.Clear();
        chkActive.Checked = true;
        dgvRecipe.DataSource = null;
        txtName.Focus();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        if (name == "") { MessageBox.Show("Enter the item name."); return; }
        if (!decimal.TryParse(txtPrice.Text, out var price) || price < 0)
        { MessageBox.Show("Enter a valid price."); return; }
        if (cboCategory.SelectedValue == null) { MessageBox.Show("Choose a category."); return; }
        int cat = Convert.ToInt32(cboCategory.SelectedValue);

        try
        {
            if (_selectedId == 0)
                ExecuteNonQuery(
                    "INSERT INTO MenuItems (ItemName, CategoryID, BasePrice, IsActive) VALUES (?, ?, ?, ?)",
                    P(name), P(cat), P(price), P(chkActive.Checked));
            else
                ExecuteNonQuery(
                    "UPDATE MenuItems SET ItemName = ?, CategoryID = ?, BasePrice = ?, IsActive = ? WHERE ItemID = ?",
                    P(name), P(cat), P(price), P(chkActive.Checked), P(_selectedId));

            LoadItems();
            SelectByName(name);   // keeps the item selected so you can add its recipe next
            MessageBox.Show("Item saved. Now check or add its ingredients below.");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not save: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SelectByName(string name)
    {
        foreach (DataGridViewRow row in dgvItems.Rows)
        {
            if (row.Cells["Item"].Value?.ToString() == name)
            {
                dgvItems.CurrentCell = row.Cells["Item"];
                row.Selected = true;
                break;
            }
        }
    }

    private void LoadRecipe()
    {
        if (_selectedId == 0) { dgvRecipe.DataSource = null; return; }
        dgvRecipe.DataSource = GetData(
            "SELECT r.RecipeID, g.IngredientName AS [Ingredient], r.QuantityUsed AS [Qty per serving], g.UnitName AS [Unit] " +
            "FROM Recipes AS r INNER JOIN Ingredients AS g ON r.IngredientID = g.IngredientID " +
            "WHERE r.ItemID = ?", P(_selectedId));
        dgvRecipe.Columns["RecipeID"].Visible = false;
    }

    private void btnAddIngredient_Click(object? sender, EventArgs e)
    {
        if (_selectedId == 0) { MessageBox.Show("Save or select a menu item first."); return; }
        if (cboIngredient.SelectedValue == null) return;
        if (!double.TryParse(txtQtyUsed.Text, out var qty) || qty <= 0)
        { MessageBox.Show("Enter a quantity greater than zero."); return; }

        int ing = Convert.ToInt32(cboIngredient.SelectedValue);
        ExecuteNonQuery("DELETE FROM Recipes WHERE ItemID = ? AND IngredientID = ?", P(_selectedId), P(ing));
        ExecuteNonQuery("INSERT INTO Recipes (ItemID, IngredientID, QuantityUsed) VALUES (?, ?, ?)",
            P(_selectedId), P(ing), P(qty));
        txtQtyUsed.Clear();
        LoadRecipe();
    }

    private void btnRemoveIngredient_Click(object? sender, EventArgs e)
    {
        if (dgvRecipe.CurrentRow == null) return;
        int id = Convert.ToInt32(dgvRecipe.CurrentRow.Cells["RecipeID"].Value);
        ExecuteNonQuery("DELETE FROM Recipes WHERE RecipeID = ?", P(id));
        LoadRecipe();
    }
}