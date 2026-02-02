using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Exceptions.Base;

namespace DesafioSpedy.Domain.Entities;

public class User : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    public void ValidarLogin(string password, IPasswordEncryptor encryptor)
    {
        if (!encryptor.Verify(password, Password))
            throw new CredenciaisInvalidasException("Email ou Senha incorretos.");
    }

}
