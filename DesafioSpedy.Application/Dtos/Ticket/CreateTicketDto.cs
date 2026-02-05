using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Application.Dtos.Ticket;

public class CreateTicketDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ETicketPriority Priority { get; set; }
    public Guid ResponsableUserId { get; set; }
}
