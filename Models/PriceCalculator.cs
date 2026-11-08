namespace CoffeeManagementSystem;

public static class PriceCalculator
{
    public static decimal SizeSurcharge(string size) => size switch
    {
        "Medium" => 15m,
        "Large" => 30m,
        _ => 0m
    };

    public static decimal UnitPrice(decimal basePrice, string size) => basePrice + SizeSurcharge(size);

    // Rounds to 2 decimals; discount can never exceed the subtotal.
    public static decimal Total(decimal subtotal, decimal discount) =>
        Math.Round(Math.Max(0m, subtotal - Math.Max(0m, discount)), 2);
}