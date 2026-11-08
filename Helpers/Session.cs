namespace CoffeeManagementSystem;

public static class Session
{
    public static int UserId { get; set; }
    public static string FullName { get; set; } = "";
    public static string Role { get; set; } = "";
    public static bool IsAdmin => Role == "Administrator";

    public static void Clear() { UserId = 0; FullName = ""; Role = ""; }
}