namespace CoffeeManagementSystem;

public class CartLine
{
    public int ItemID { get; set; }
    public string ItemName { get; set; } = "";
    public string SizeName { get; set; } = "Small";
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => UnitPrice * Quantity;
}