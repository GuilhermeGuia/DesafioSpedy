namespace DesafioSpedy.Application.Dtos.Ticket;

public class GetTicketDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Status { get; set; }
    public int Priority { get; set; }
    public string ResponsableName { get; set; } = string.Empty;
    public string CreatorName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public bool IsDeleted { get; set; }
    public Guid ResponsableUserId { get; set; }
}
