using DesafioSpedy.Application.Authorization;
using DesafioSpedy.Application.Dtos.Auth;
using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Repositories;

namespace DesafioSpedy.Application.Services;

public class AuthenticationService(IAuthRepository _authRepository, IPasswordEncryptor _encryptor, IJwtGenerator _jwtGenerator)
{
    public async Task<LoginResponseDto> Login(CredentialsDto dto)
    {
        // validacao de entrada fluent validator
        var user = await _authRepository.GetByEmail(dto.Email);

        if (user == null)
            throw new Exception("Email ou Senha incorretos.");

        user.ValidarLogin(dto.Password, _encryptor);




        var token = _jwtGenerator.GenerateToken(tecnicoLogin);

        var response = new LoginResponseDto
        {
            Token = "fake-jwt-token",
        };

        return response;
    }
}
