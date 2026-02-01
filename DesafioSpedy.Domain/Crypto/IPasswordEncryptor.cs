namespace DesafioSpedy.Domain.Crypto;

public interface IPasswordEncryptor
{
    string Hash(string plainPassword);
    bool Verify(string plainPassword, string hashedPassword);
}
