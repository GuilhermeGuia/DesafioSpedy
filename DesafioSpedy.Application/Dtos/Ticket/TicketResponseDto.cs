namespace DesafioSpedy.Application.Dtos.Ticket;

public class TicketResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status  { get; set; }
    public DateTime CreatedAt { get; set; }
    public static TicketResponseDto From(Domain.Entities.Ticket ticket)
    {
        return new TicketResponseDto
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            Status = ticket.Status.ToString(),
            Priority = ticket.Priority.ToString(),
            CreatedAt = ticket.CreatedAt
        };
    }
}
