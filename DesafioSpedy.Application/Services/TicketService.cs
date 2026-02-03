using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.Repositories;
using DesafioSpedy.Exceptions.Base;
using FluentValidation;

namespace DesafioSpedy.Application.Services;

public class TicketService(IValidator<CreateTicketDto> _validator, IUserRepository _userRepository, ITicketRepository _ticketRepository, IUnitOfWork _unitOfWork)
{
    public async Task<TicketResponseDto> Create(CreateTicketDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            throw new CreateTicketException("");

        var assignedUser = _userRepository.GetById(dto.AssignedUserId);
        if(assignedUser == null)
            throw new CreateTicketException("Usuário atribuído não encontrado.");

        var mappedDto = new Ticket(dto.Title, dto.Description, dto.Priority, dto.AssignedUserId);

        await _ticketRepository.CreateTicket(mappedDto);

        await _unitOfWork.SaveChangesAsync();

        return TicketResponseDto.From(mappedDto);
    }
}
