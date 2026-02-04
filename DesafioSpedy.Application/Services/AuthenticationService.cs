using DesafioSpedy.Application.Dtos.Auth;
using DesafioSpedy.Domain.Authorization;
using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Repositories;
using DesafioSpedy.Exceptions.Base;
using FluentValidation;

namespace DesafioSpedy.Application.Services;

public class AuthenticationService(IUserRepository _authRepository, IPasswordEncryptor _encryptor, IJwtGenerator _jwtGenerator, IValidator<CredentialsDto> _validator)
{
    public async Task<LoginResponseDto> Login(CredentialsDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if(!validationResult.IsValid)
            throw new CredenciaisInvalidasException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

        var user = await _authRepository.GetByEmail(dto.Email);

        if (user == null)
            throw new CredenciaisInvalidasException("Email ou Senha incorretos.");

        if(!_encryptor.Verify(dto.Password, user.Password))
            throw new CredenciaisInvalidasException("Email ou Senha incorretos.");

        var token = _jwtGenerator.GenerateToken(user.Id, user.Name, user.Email);

        var response = new LoginResponseDto
        {
            Token = token,
        };

        return response;
    }
}
