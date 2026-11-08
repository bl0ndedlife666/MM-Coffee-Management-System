using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class SupplierForm : Form
{
    private int _selectedId = 0;

    public SupplierForm()
    {
        InitializeComponent();
        Load += (s, e) => LoadSuppliers();
        dgvSuppliers.SelectionChanged += (s, e) => FillFromGrid();
        btnNew.Click += (s, e) => ClearForm();
        btnSave.Click += btnSave_Click;
    }

    private void LoadSuppliers()
    {
        dgvSuppliers.DataSource = GetData(
            "SELECT SupplierID, SupplierName AS [Supplier], ContactNumber AS [Contact], Address " +
            "FROM Suppliers ORDER BY SupplierName");
        dgvSuppliers.Columns["SupplierID"].Visible = false;
    }

    private int Get_selectedId()
    {
        return _selectedId;
    }

    private void FillFromGrid()
    {
        if (dgvSuppliers.CurrentRow == null || !dgvSuppliers.Columns.Contains("SupplierID")) return;
        var c = dgvSuppliers.CurrentRow.Cells;
        if (c["SupplierID"].Value is null or DBNull) return;   // <-- add this line
        _selectedId = Convert.ToInt32(c["SupplierID"].Value);
}

    private void ClearForm()
    {
        _selectedId = 0;
        txtName.Clear(); txtContact.Clear(); txtAddress.Clear();
        txtName.Focus();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        if (name == "") { MessageBox.Show("Enter the supplier name."); return; }

        try
        {
            if (_selectedId == 0)
                ExecuteNonQuery(
                    "INSERT INTO Suppliers (SupplierName, ContactNumber, Address) VALUES (?, ?, ?)",
                    P(name), P(txtContact.Text.Trim()), P(txtAddress.Text.Trim()));
            else
                ExecuteNonQuery(
                    "UPDATE Suppliers SET SupplierName = ?, ContactNumber = ?, Address = ? WHERE SupplierID = ?",
                    P(name), P(txtContact.Text.Trim()), P(txtAddress.Text.Trim()), P(_selectedId));

            LoadSuppliers();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not save: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}