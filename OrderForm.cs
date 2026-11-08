using System.ComponentModel;
using System.Drawing.Printing;
using System.Text;
using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public partial class OrderForm : Form
{
    private readonly BindingList<CartLine> _cart = new();
    private string _receiptText = "";

    public OrderForm()
    {
        InitializeComponent();
        Load += OrderForm_Load;
        cboCategory.SelectedIndexChanged += (s, e) => LoadMenu();
        cboPayment.SelectedIndexChanged += (s, e) =>
        {
            txtCash.Enabled = cboPayment.Text == "Cash";
            UpdateTotals();
        };
        txtDiscount.TextChanged += (s, e) => UpdateTotals();
        txtCash.TextChanged += (s, e) => UpdateTotals();
        btnAdd.Click += btnAdd_Click;
        btnRemove.Click += btnRemove_Click;
        btnClear.Click += (s, e) => _cart.Clear();
        btnCheckout.Click += btnCheckout_Click;
    }

    private void OrderForm_Load(object? sender, EventArgs e)
    {
        cboSize.Items.AddRange(new object[] { "Small", "Medium", "Large" });
        cboSize.SelectedIndex = 0;
        cboPayment.Items.AddRange(new object[] { "Cash", "Card", "E-Wallet" });
        cboPayment.SelectedIndex = 0;

        cboCategory.DisplayMember = "CategoryName";
        cboCategory.ValueMember = "CategoryID";
        cboCategory.DataSource = GetData("SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName");
        LoadMenu();

        dgvCart.DataSource = _cart;
        _cart.ListChanged += (s, a) => UpdateTotals();
        UpdateTotals();
    }

    private void LoadMenu()
    {
        if (cboCategory.SelectedValue is not int categoryId) return;
        dgvMenu.DataSource = GetData(
            "SELECT ItemID, ItemName, BasePrice FROM MenuItems WHERE CategoryID = ? AND IsActive = True ORDER BY ItemName",
            P(categoryId));
        if (dgvMenu.Columns.Contains("ItemID")) dgvMenu.Columns["ItemID"].Visible = false;
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        if (dgvMenu.CurrentRow?.DataBoundItem is not DataRowView view)
        {
            MessageBox.Show("Select a menu item first.");
            return;
        }

        int itemId = Convert.ToInt32(view["ItemID"]);
        string size = cboSize.Text;
        int qty = (int)nudQty.Value;
        decimal price = PriceCalculator.UnitPrice(Convert.ToDecimal(view["BasePrice"]), size);

        var existing = _cart.FirstOrDefault(l => l.ItemID == itemId && l.SizeName == size);
        if (existing != null)
        {
            existing.Quantity += qty;
            _cart.ResetBindings();
        }
        else
        {
            _cart.Add(new CartLine
            {
                ItemID = itemId,
                ItemName = view["ItemName"].ToString()!,
                SizeName = size,
                Quantity = qty,
                UnitPrice = price
            });
        }
        nudQty.Value = 1;
    }

    private void btnRemove_Click(object? sender, EventArgs e)
    {
        if (dgvCart.CurrentRow?.DataBoundItem is CartLine line) _cart.Remove(line);
    }

    private decimal GetDiscount() =>
        decimal.TryParse(txtDiscount.Text, out var d) && d >= 0 ? d : 0m;

    private void UpdateTotals()
    {
        decimal subtotal = _cart.Sum(l => l.LineTotal);
        decimal total = PriceCalculator.Total(subtotal, GetDiscount());
        lblSubtotal.Text = $"Subtotal: {subtotal:N2}";
        lblTotal.Text = $"TOTAL: {total:N2}";
        lblChange.Text = decimal.TryParse(txtCash.Text, out var cash)
            ? $"Change: {Math.Max(0m, cash - total):N2}"
            : "Change: 0.00";
    }

    // Returns the name of the first ingredient that is short, or null if stock is enough
    private string? FindShortage()
    {
        var need = new Dictionary<int, double>();
        foreach (var l in _cart)
        {
            var rec = GetData("SELECT IngredientID, QuantityUsed FROM Recipes WHERE ItemID = ?", P(l.ItemID));
            foreach (DataRow r in rec.Rows)
            {
                int ing = Convert.ToInt32(r[0]);
                need[ing] = need.GetValueOrDefault(ing) + Convert.ToDouble(r[1]) * l.Quantity;
            }
        }
        foreach (var (ing, qty) in need)
        {
            var d = GetData("SELECT IngredientName, QuantityOnHand FROM Ingredients WHERE IngredientID = ?", P(ing));
            if (d.Rows.Count > 0 && Convert.ToDouble(d.Rows[0][1]) < qty)
                return d.Rows[0][0].ToString();
        }
        return null;
    }

    private void btnCheckout_Click(object? sender, EventArgs e)
    {
        if (_cart.Count == 0)
        {
            MessageBox.Show("The order is empty.");
            return;
        }

        decimal subtotal = _cart.Sum(l => l.LineTotal);
        decimal discount = GetDiscount();
        decimal total = PriceCalculator.Total(subtotal, discount);

        if (discount > subtotal)
        {
            MessageBox.Show("The discount cannot be more than the subtotal.");
            return;
        }
        if (cboPayment.Text == "Cash" && (!decimal.TryParse(txtCash.Text, out var cash) || cash < total))
        {
            MessageBox.Show("The amount received is less than the total.");
            return;
        }

        string? shortage = FindShortage();
        if (shortage != null)
        {
            MessageBox.Show($"Not enough {shortage} in stock for this order.", "Low stock",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            int orderId = OrderService.SaveOrder(_cart.ToList(), discount, cboPayment.Text);
            BuildReceipt(orderId, subtotal, discount, total);
            ShowReceipt();
            _cart.Clear();
            txtDiscount.Text = "0";
            txtCash.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not save the order: " + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BuildReceipt(int orderId, decimal subtotal, decimal discount, decimal total)
    {
        var sb = new StringBuilder();
        sb.AppendLine("        COFFEE SHOP");
        sb.AppendLine($"Order #{orderId}");
        sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
        sb.AppendLine($"Cashier: {Session.FullName}");
        sb.AppendLine(new string('-', 36));
        foreach (var l in _cart)
            sb.AppendLine($"{l.Quantity} x {l.ItemName} ({l.SizeName})".PadRight(26) + l.LineTotal.ToString("N2").PadLeft(10));
        sb.AppendLine(new string('-', 36));
        sb.AppendLine("Subtotal".PadRight(26) + subtotal.ToString("N2").PadLeft(10));
        sb.AppendLine("Discount".PadRight(26) + discount.ToString("N2").PadLeft(10));
        sb.AppendLine("TOTAL".PadRight(26) + total.ToString("N2").PadLeft(10));
        sb.AppendLine("Payment: " + cboPayment.Text);
        sb.AppendLine();
        sb.AppendLine("   Thank you! Come again.");
        _receiptText = sb.ToString();
    }

    private void ShowReceipt()
    {
        var doc = new PrintDocument();
        doc.PrintPage += (s, e) =>
        {
            using var font = new Font("Consolas", 9);
            e.Graphics!.DrawString(_receiptText, font, Brushes.Black, 10, 10);
        };
        using var preview = new PrintPreviewDialog { Document = doc, Width = 500, Height = 700 };
        preview.ShowDialog();   // the preview window also has a Print button
    }
}