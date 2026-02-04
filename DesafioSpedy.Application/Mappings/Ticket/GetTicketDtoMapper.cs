using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Domain.Entities;

namespace DesafioSpedy.Application.Tickets.Mappings;

public static class TicketMappings
{
    public static GetTicketDto ToGetDto(this Ticket ticket)
    {
        return new GetTicketDto
        {
            Id = ticket.Id.ToString(),
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status.ToString(),
            Priority = ticket.Priority.ToString(),
            AssignedUserId = ticket.AssignedUserId.ToString(),
            ClosedAt = ticket.ClosedAt,
            IsDeleted = ticket.IsDeleted
        };
    }
}
