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

public class TicketService(IValidator<CreateTicketDto> _validator, IUserRepository _userRepository, ITicketRepository _ticketRepository, IUnitOfWork _unitOfWork, ICurrentUser _currentUser)
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
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            throw new CreateTicketException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());

        var responsableUserId = _userRepository.GetById(dto.ResponsableUserId);
        if(responsableUserId == null)
            throw new CreateTicketException("Usuário responsável não encontrado.");

        var createdByUserId = _currentUser.UserId;

        var mappedDto = new Ticket(dto.Title, dto.Description, dto.Priority, dto.ResponsableUserId, createdByUserId);

        await _ticketRepository.CreateAsync(mappedDto);

        await _unitOfWork.SaveChangesAsync();

        // nao retorna dados do criador nem do responsavel -> analisar
        return TicketResponseDto.From(mappedDto);
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

        if(ticket.Status == Domain.ValueObjects.Ticket.ETicketStatus.Finished)
            throw new DeleteTicketException("Ticket possui status finalizado.");

        ticket.DeletarTicket();

        await _unitOfWork.SaveChangesAsync();
    }
}
