using System.Security.Cryptography;
using System.Text;

namespace CoffeeManagementSystem;

public static class PasswordHelper
{
    public static string HashPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(Compute(password, salt));
    }

    public static bool VerifyPassword(string password, string stored)
    {
        var parts = stored.Split(':');
        if (parts.Length != 2) return false;
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] expected = Convert.FromBase64String(parts[1]);
        return CryptographicOperations.FixedTimeEquals(Compute(password, salt), expected);
    }

    private static byte[] Compute(string password, byte[] salt)
    {
        byte[] pw = Encoding.UTF8.GetBytes(password);
        return SHA256.HashData(salt.Concat(pw).ToArray());
    }
}