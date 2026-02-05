using DesafioSpedy.Application.Dtos.Base;
using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Application.Extensions;
using DesafioSpedy.Application.Tickets.Mappings;
using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.Http;
using DesafioSpedy.Domain.Repositories;
using DesafioSpedy.Exceptions.Base;
using FluentValidation;

namespace DesafioSpedy.Application.Services;

public class TicketService(IValidator<CreateTicketDto> _validateCreateTicket, IValidator<UpdateTicketDto> _validateUpdateTicket, IUserRepository _userRepository, ITicketRepository _ticketRepository, IUnitOfWork _unitOfWork, ICurrentUser _currentUser)
{
    public PagedResult<GetTicketDto> GetAllAsync(GetTicketFilterDto filters)
    {
        var query = _ticketRepository.Query();

        query = query.ApplyFilters(filters);

        var total = query.Count();

        var items = query
            .OrderByDescending(x => x.CreatedAt)
            .ApplyPaging(filters.Page, filters.PageSize)
            .Select(x => x.ToGetDto())
            .ToList();

        return new PagedResult<GetTicketDto>
        {
            Items = items,
            Total = total
        };
    }

    public async Task<TicketResponseDto> Create(CreateTicketDto dto)
    {
        var validationResult = await _validateCreateTicket.ValidateAsync(dto);
        if (!validationResult.IsValid)
            throw new CreateTicketException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

        var responsableUserId = _userRepository.GetById(dto.ResponsableUserId);
        if (responsableUserId == null)
            throw new CreateTicketException("Usuário responsável não encontrado.");

        var createdByUserId = _currentUser.UserId;

        var mappedDto = new Ticket(dto.Title, dto.Description, dto.Priority, dto.ResponsableUserId, createdByUserId);

        await _ticketRepository.CreateAsync(mappedDto);

        await _unitOfWork.SaveChangesAsync();

        return TicketResponseDto.From(mappedDto);
    }

    public async Task<TicketResponseDto> Update(UpdateTicketDto dto)
    {
        var validationResult = await _validateUpdateTicket.ValidateAsync(dto);
        if (!validationResult.IsValid)
            throw new UpdateStatusTicketException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

        var responsableUserId = _userRepository.GetById(dto.ResponsableUserId);
        if (responsableUserId == null)
            throw new UpdateStatusTicketException("Usuário responsável não encontrado.");

        var ticket = await _ticketRepository.FindAsync(dto.Id);

        if (ticket == null)
            throw new DeleteTicketException("Ticket não encontrado.");

        ticket.AtualizarDados(dto.Title, dto.Description, dto.Priority, dto.ResponsableUserId);

        await _unitOfWork.SaveChangesAsync();

        return TicketResponseDto.From(ticket);
    }

    public async Task AvancarTicket(Guid Id)
    {

        var ticket = await _ticketRepository.FindAsync(Id);

        if (ticket == null)
            throw new DeleteTicketException("Ticket não encontrado.");

        ticket.AvancarStatus();

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task Delete(Guid Id)
    {
        var ticket = await _ticketRepository.FindAsync(Id);

        if(ticket == null)
            throw new DeleteTicketException("Ticket não encontrado.");

        ticket.DeletarTicket();

        await _unitOfWork.SaveChangesAsync();
    }
}
