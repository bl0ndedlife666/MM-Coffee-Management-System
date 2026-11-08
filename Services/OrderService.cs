using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public static class OrderService
{
    public static int SaveOrder(List<CartLine> cart, decimal discount, string paymentMethod)
    {
        decimal subtotal = cart.Sum(l => l.LineTotal);
        decimal total = PriceCalculator.Total(subtotal, discount);

        using var conn = new OleDbConnection(ConnectionString);
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            int orderId;
            using (var cmd = new OleDbCommand(
                "INSERT INTO Orders (OrderDate, UserID, Subtotal, Discount, TotalAmount, PaymentMethod, OrderStatus) VALUES (?, ?, ?, ?, ?, ?, 'Completed')",
                conn, tx))
            {
                cmd.Parameters.AddRange(new[]
                {
                    P(DateTime.Now), P(Session.UserId), P(subtotal), P(discount), P(total), P(paymentMethod)
                });
                cmd.ExecuteNonQuery();
            }

            using (var idCmd = new OleDbCommand("SELECT @@IDENTITY", conn, tx))
                orderId = Convert.ToInt32(idCmd.ExecuteScalar());

            foreach (var line in cart)
            {
                using (var cmd = new OleDbCommand(
                    "INSERT INTO OrderItems (OrderID, ItemID, SizeName, Quantity, UnitPrice) VALUES (?, ?, ?, ?, ?)",
                    conn, tx))
                {
                    cmd.Parameters.AddRange(new[]
                    {
                        P(orderId), P(line.ItemID), P(line.SizeName), P(line.Quantity), P(line.UnitPrice)
                    });
                    cmd.ExecuteNonQuery();
                }

                // Deduct every ingredient in this item's recipe
                var recipe = new List<(int Ing, double Qty)>();
                using (var rc = new OleDbCommand(
                    "SELECT IngredientID, QuantityUsed FROM Recipes WHERE ItemID = ?", conn, tx))
                {
                    rc.Parameters.Add(P(line.ItemID));
                    using var rd = rc.ExecuteReader();
                    while (rd.Read())
                        recipe.Add((Convert.ToInt32(rd[0]), Convert.ToDouble(rd[1])));
                }

                foreach (var (ing, qty) in recipe)
                {
                    using var dc = new OleDbCommand(
                        "UPDATE Ingredients SET QuantityOnHand = QuantityOnHand - ? WHERE IngredientID = ?",
                        conn, tx);
                    dc.Parameters.AddRange(new[] { P(qty * line.Quantity), P(ing) });
                    dc.ExecuteNonQuery();
                }
            }

            tx.Commit();
            return orderId;
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    // Restores stock and marks the order as Voided
    public static void VoidOrder(int orderId)
    {
        using var conn = new OleDbConnection(ConnectionString);
        conn.Open();
        using var tx = conn.BeginTransaction();
        try
        {
            var lines = new List<(int Item, int Qty)>();
            using (var c = new OleDbCommand("SELECT ItemID, Quantity FROM OrderItems WHERE OrderID = ?", conn, tx))
            {
                c.Parameters.Add(P(orderId));
                using var rd = c.ExecuteReader();
                while (rd.Read()) lines.Add((Convert.ToInt32(rd[0]), Convert.ToInt32(rd[1])));
            }

            foreach (var (item, qty) in lines)
            {
                var recipe = new List<(int Ing, double Q)>();
                using (var rc = new OleDbCommand("SELECT IngredientID, QuantityUsed FROM Recipes WHERE ItemID = ?", conn, tx))
                {
                    rc.Parameters.Add(P(item));
                    using var rd = rc.ExecuteReader();
                    while (rd.Read()) recipe.Add((Convert.ToInt32(rd[0]), Convert.ToDouble(rd[1])));
                }
                foreach (var (ing, q) in recipe)
                {
                    using var uc = new OleDbCommand(
                        "UPDATE Ingredients SET QuantityOnHand = QuantityOnHand + ? WHERE IngredientID = ?", conn, tx);
                    uc.Parameters.AddRange(new[] { P(q * qty), P(ing) });
                    uc.ExecuteNonQuery();
                }
            }

            using (var vc = new OleDbCommand("UPDATE Orders SET OrderStatus = 'Voided' WHERE OrderID = ?", conn, tx))
            {
                vc.Parameters.Add(P(orderId));
                vc.ExecuteNonQuery();
            }
            tx.Commit();
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }
}