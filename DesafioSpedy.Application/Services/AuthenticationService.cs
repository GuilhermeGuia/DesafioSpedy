using DesafioSpedy.Application.Dtos.Auth;
using DesafioSpedy.Domain.Authorization;
using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Repositories;
using DesafioSpedy.Exceptions.Base;

namespace DesafioSpedy.Application.Services;

public class AuthenticationService(IAuthRepository _authRepository, IPasswordEncryptor _encryptor, IJwtGenerator _jwtGenerator)
{
    public async Task<LoginResponseDto> Login(CredentialsDto dto)
    {
        var user = await _authRepository.GetByEmail(dto.Email);

        if (user == null)
            throw new CredenciaisInvalidasException("Email ou Senha incorretos.");

        user.ValidarLogin(dto.Password, _encryptor);

        var token = _jwtGenerator.GenerateToken(user.Id, user.Name, user.Email);

        var response = new LoginResponseDto
        {
            Token = token,
        };

        return response;
    }
}
