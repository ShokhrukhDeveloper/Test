using System.Security.Cryptography;
using System.Text;

namespace Test.Api.Extensions;

public static class HashExtension
{
    public static string ToSha256(this string input)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);
        using var sha256 = SHA256.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = sha256.ComputeHash(inputBytes);
        return Encoding.UTF8.GetString(hashBytes);
    }
}