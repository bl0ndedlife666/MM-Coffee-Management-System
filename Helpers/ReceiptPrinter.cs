using System.Drawing.Printing;
using System.Text;
using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public static class ReceiptPrinter
{
    public static string Build(int orderId, bool reprint)
    {
        var o = GetData(
            "SELECT o.OrderDate, o.Subtotal, o.Discount, o.TotalAmount, o.PaymentMethod, o.OrderStatus, " +
            "o.OrderType, o.CustomerName, u.FullName " +
            "FROM Orders AS o LEFT JOIN Users AS u ON o.UserID = u.UserID WHERE o.OrderID = ?",
            P(orderId));
        if (o.Rows.Count == 0) return "Order not found.";
        var r = o.Rows[0];

        var lines = GetData(
            "SELECT m.ItemName, oi.SizeName, oi.Quantity, oi.UnitPrice " +
            "FROM OrderItems AS oi INNER JOIN MenuItems AS m ON oi.ItemID = m.ItemID WHERE oi.OrderID = ?",
            P(orderId));

        var sb = new StringBuilder();
        sb.AppendLine("        COFFEE SHOP");
        if (reprint) sb.AppendLine("      *** REPRINT ***");
        if (r["OrderStatus"].ToString() == "Voided") sb.AppendLine("      *** VOIDED ***");
        sb.AppendLine($"Order #{orderId}");
        sb.AppendLine(Convert.ToDateTime(r["OrderDate"]).ToString("yyyy-MM-dd hh:mm tt"));
        sb.AppendLine($"Cashier: {r["FullName"]}");
        string type = r["OrderType"].ToString() ?? "";
        string who = r["CustomerName"].ToString() ?? "";
        if (type != "") sb.AppendLine($"Type: {type}");
        if (who != "") sb.AppendLine($"Customer/Table: {who}");
        sb.AppendLine(new string('-', 36));

        foreach (DataRow l in lines.Rows)
        {
            int qty = Convert.ToInt32(l["Quantity"]);
            decimal total = qty * Convert.ToDecimal(l["UnitPrice"]);
            sb.AppendLine($"{qty} x {l["ItemName"]} ({l["SizeName"]})".PadRight(26) + total.ToString("N2").PadLeft(10));
        }

        sb.AppendLine(new string('-', 36));
        sb.AppendLine("Subtotal".PadRight(26) + Convert.ToDecimal(r["Subtotal"]).ToString("N2").PadLeft(10));
        sb.AppendLine("Discount".PadRight(26) + Convert.ToDecimal(r["Discount"]).ToString("N2").PadLeft(10));
        sb.AppendLine("TOTAL".PadRight(26) + Convert.ToDecimal(r["TotalAmount"]).ToString("N2").PadLeft(10));
        sb.AppendLine("Payment: " + r["PaymentMethod"]);
        sb.AppendLine();
        sb.AppendLine("   Thank you! Come again.");
        return sb.ToString();
    }

    public static void Show(int orderId, bool reprint = false)
    {
        string text = Build(orderId, reprint);
        var doc = new PrintDocument();
        doc.PrintPage += (s, e) =>
        {
            using var font = new Font("Consolas", 9);
            e.Graphics!.DrawString(text, font, Brushes.Black, 10, 10);
        };
        using var preview = new PrintPreviewDialog { Document = doc, Width = 500, Height = 700 };
        preview.ShowDialog();
    }
}