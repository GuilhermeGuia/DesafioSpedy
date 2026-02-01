using DesafioSpedy.Domain.Crypto;
using Microsoft.AspNetCore.Identity;

namespace DesafioSpedy.Infrastructure.Crypto;

public class PasswordEncryptor : IPasswordEncryptor
{
    private readonly PasswordHasher<object> _hasher = new();

    public string Hash(string plainPassword)
    {
        return _hasher.HashPassword(null, plainPassword);
    }

    public bool Verify(string plainPassword, string hashedPassword)
    {
        var result = _hasher.VerifyHashedPassword(null, hashedPassword, plainPassword);
        return result == PasswordVerificationResult.Success;
    }
}
