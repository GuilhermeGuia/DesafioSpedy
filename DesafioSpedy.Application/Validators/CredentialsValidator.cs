using DesafioSpedy.Application.Dtos.Auth;
using FluentValidation;

namespace DesafioSpedy.Application.Validators;

public class CredentialsValidator : AbstractValidator<CredentialsDto>
{
    public CredentialsValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O campo Email é obrigatório.")
            .EmailAddress().WithMessage("O campo Email deve ser um endereço de email válido.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("O campo Senha é obrigatório.")
            .MinimumLength(6).WithMessage("O campo Senha deve ter no mínimo 6 caracteres.");
    }
}
