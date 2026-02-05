using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Domain.Entities;

namespace DesafioSpedy.Application.Tickets.Mappings;

public static class TicketMappings
{
    public static GetTicketDto ToGetDto(this Ticket ticket)
    {
        return new GetTicketDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = (int) ticket.Status,
            Priority = (int) ticket.Priority,
            ResponsableUserId = ticket.ResponsableUserId,
            ClosedAt = ticket.FinishedAt,
            CreatedAt = ticket.CreatedAt,
            IsDeleted = ticket.IsDeleted,
            CreatorName = ticket.Creator.Name,
            ResponsableName = ticket.Responsable.Name
        };
    }
}
