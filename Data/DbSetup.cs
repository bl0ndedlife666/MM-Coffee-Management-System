using static CoffeeManagementSystem.DatabaseHelper;

namespace CoffeeManagementSystem;

public static class DbSetup
{
    public static void EnsureCreated()
    {
        using var conn = new OleDbConnection(ConnectionString);
        conn.Open();

        var existing = conn.GetSchema("Tables", new string?[] { null, null, null, "TABLE" })
            .AsEnumerable()
            .Select(r => r["TABLE_NAME"].ToString()!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        void Make(string name, string ddl)
        {
            if (existing.Contains(name)) return;
            using var cmd = new OleDbCommand(ddl, conn);
            cmd.ExecuteNonQuery();
        }

        Make("Categories", "CREATE TABLE Categories (CategoryID AUTOINCREMENT PRIMARY KEY, CategoryName TEXT(50) NOT NULL)");
        Make("MenuItems", "CREATE TABLE MenuItems (ItemID AUTOINCREMENT PRIMARY KEY, ItemName TEXT(100) NOT NULL, CategoryID LONG, BasePrice CURRENCY, IsActive YESNO)");
        Make("Suppliers", "CREATE TABLE Suppliers (SupplierID AUTOINCREMENT PRIMARY KEY, SupplierName TEXT(100) NOT NULL, ContactNumber TEXT(30), Address TEXT(200))");
        Make("Ingredients", "CREATE TABLE Ingredients (IngredientID AUTOINCREMENT PRIMARY KEY, IngredientName TEXT(100) NOT NULL, UnitName TEXT(20), QuantityOnHand DOUBLE, ReorderLevel DOUBLE, SupplierID LONG)");
        Make("Recipes", "CREATE TABLE Recipes (RecipeID AUTOINCREMENT PRIMARY KEY, ItemID LONG, IngredientID LONG, QuantityUsed DOUBLE)");
        Make("StockIns", "CREATE TABLE StockIns (StockInID AUTOINCREMENT PRIMARY KEY, IngredientID LONG, SupplierID LONG, Quantity DOUBLE, UnitCost CURRENCY, DateReceived DATETIME)");
        Make("Users", "CREATE TABLE Users (UserID AUTOINCREMENT PRIMARY KEY, FullName TEXT(100), Username TEXT(50) NOT NULL, PasswordHash TEXT(255), RoleName TEXT(20), CreatedDate DATETIME)");
        Make("Orders", "CREATE TABLE Orders (OrderID AUTOINCREMENT PRIMARY KEY, OrderDate DATETIME, UserID LONG, Subtotal CURRENCY, Discount CURRENCY, TotalAmount CURRENCY, PaymentMethod TEXT(20), OrderStatus TEXT(20))");
        Make("OrderItems", "CREATE TABLE OrderItems (OrderItemID AUTOINCREMENT PRIMARY KEY, OrderID LONG, ItemID LONG, SizeName TEXT(20), Quantity LONG, UnitPrice CURRENCY)");
    }

    public static void SeedIfEmpty()
    {
        if (Convert.ToInt32(ExecuteScalar("SELECT COUNT(*) FROM Users")) > 0) return;

        // Default administrator: admin / admin123 (change after first login)
        ExecuteNonQuery(
            "INSERT INTO Users (FullName, Username, PasswordHash, RoleName, CreatedDate) VALUES (?, ?, ?, ?, ?)",
            P("System Administrator"), P("admin"), P(PasswordHelper.HashPassword("admin123")),
            P("Administrator"), P(DateTime.Now));

        foreach (var c in new[] { "Hot Coffee", "Iced Coffee", "Non-Coffee", "Pastries" })
            ExecuteNonQuery("INSERT INTO Categories (CategoryName) VALUES (?)", P(c));

        var items = new (string Name, int Cat, decimal Price)[]
        {
            ("Espresso", 1, 80m), ("Americano", 1, 100m), ("Cappuccino", 1, 120m),
            ("Caffe Latte", 1, 130m), ("Iced Americano", 2, 110m), ("Iced Latte", 2, 140m),
            ("Caramel Macchiato", 2, 150m), ("Hot Chocolate", 3, 120m),
            ("Matcha Latte", 3, 140m), ("Croissant", 4, 90m), ("Blueberry Muffin", 4, 85m)
        };
        foreach (var i in items)
            ExecuteNonQuery("INSERT INTO MenuItems (ItemName, CategoryID, BasePrice, IsActive) VALUES (?, ?, ?, ?)",
                P(i.Name), P(i.Cat), P(i.Price), P(true));

        var ingredients = new (string Name, string Unit, double Qty, double Reorder)[]
        {
            ("Coffee Beans", "g", 5000, 500), ("Fresh Milk", "ml", 10000, 1000),
            ("Cups", "pcs", 200, 30), ("Caramel Syrup", "ml", 1500, 200)
        };
        foreach (var g in ingredients)
            ExecuteNonQuery("INSERT INTO Ingredients (IngredientName, UnitName, QuantityOnHand, ReorderLevel) VALUES (?, ?, ?, ?)",
                P(g.Name), P(g.Unit), P(g.Qty), P(g.Reorder));

        // (ItemID, IngredientID, QuantityUsed). Ingredient IDs: 1 beans, 2 milk, 3 cups, 4 syrup
        var recipes = new (int Item, int Ing, double Qty)[]
        {
            (1,1,18), (1,3,1), (2,1,18), (2,3,1), (3,1,18), (3,2,150), (3,3,1),
            (4,1,18), (4,2,200), (4,3,1), (5,1,18), (5,3,1), (6,1,18), (6,2,180), (6,3,1),
            (7,1,18), (7,2,180), (7,4,20), (7,3,1)
        };
        foreach (var r in recipes)
            ExecuteNonQuery("INSERT INTO Recipes (ItemID, IngredientID, QuantityUsed) VALUES (?, ?, ?)",
                P(r.Item), P(r.Ing), P(r.Qty));
    }

    public static void EnsureColumns()
    {
        using var conn = new OleDbConnection(ConnectionString);
        conn.Open();

        var cols = conn.GetSchema("Columns", new string?[] { null, null, "Orders", null })
            .AsEnumerable()
            .Select(r => r["COLUMN_NAME"].ToString()!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        void Add(string name, string definition)
        {
            if (cols.Contains(name)) return;
            using var cmd = new OleDbCommand("ALTER TABLE Orders ADD COLUMN " + definition, conn);
            cmd.ExecuteNonQuery();
        }

        Add("OrderType", "OrderType TEXT(20)");
        Add("CustomerName", "CustomerName TEXT(60)");
    }
}