using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Application.Dtos.Ticket;

public class UpdateTicketDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ETicketPriority Priority { get; private set; }
    public ETicketStatus Status { get; private set; }
    public Guid AssignedUserId { get; private set; }
}
