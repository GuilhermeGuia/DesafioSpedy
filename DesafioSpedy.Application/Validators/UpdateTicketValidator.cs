using DesafioSpedy.Application.Dtos.Ticket;
using FluentValidation;

namespace DesafioSpedy.Application.Validators;

public class UpdateTicketValidator : AbstractValidator<UpdateTicketDto>
{
    public UpdateTicketValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage("O título é obrigatório.")
        .MinimumLength(5).WithMessage("O título deve ter no mínimo 5 caracteres.")
        .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MinimumLength(10).WithMessage("A descrição deve ter no mínimo 10 caracteres.")
            .MaximumLength(1000).WithMessage("A descrição deve ter no máximo 1000 caracteres.");

        RuleFor(x => x.Priority)
            .IsInEnum().WithMessage("Prioridade inválida.");

        RuleFor(x => x.ResponsableUserId)
            .NotEmpty().WithMessage("Usuário responsável é obrigatório.");
    }
}
