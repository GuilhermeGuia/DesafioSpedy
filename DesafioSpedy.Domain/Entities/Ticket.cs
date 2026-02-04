using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Domain.Entities;

public class Ticket : EntityBase
{
    protected Ticket() { }
    public Ticket(
       string title,
       string description,
       ETicketPriority priority,
       Guid assignedUserId)
    {
        Title = title;
        Description = description;
        Priority = priority;
        AssignedUserId = assignedUserId;

        Status = ETicketStatus.Open;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ETicketStatus Status { get; private set; }
    public ETicketPriority Priority { get; private set; }
    public DateTime? ClosedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public Guid AssignedUserId { get; private set; }
    public User User { get; private set; }

    public void DeletarTicket()
    {
        IsDeleted = true;
        UpdateAt = DateTime.UtcNow;
        ClosedAt = DateTime.UtcNow;
    }
}
