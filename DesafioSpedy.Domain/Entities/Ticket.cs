using DesafioSpedy.Domain.ValueObjects.StatusTicket;
using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Domain.Entities;

public class Ticket : EntityBase
{
    protected Ticket() { }
    public Ticket(
       string title,
       string description,
       ETicketPriority priority,
       Guid responsableUserId,
       Guid creatorUserId
       )
    {
        Title = title;
        Description = description;
        Priority = priority;
        CreatorUserId = creatorUserId;
        ResponsableUserId = responsableUserId;
        _state = new OpenState();
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    private ITicketState _state;
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ETicketStatus Status => _state.Status;
    public ETicketPriority Priority { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public Guid ResponsableUserId { get; private set; }
    public User Responsable { get; private set; }
    public Guid CreatorUserId { get; private set; }
    public User Creator { get; private set; }

    public void AvancarStatus()
    {
        _state = _state.Avancar();
    }
    public void DeletarTicket()
    {
        IsDeleted = true;
        UpdateAt = DateTime.UtcNow;
        FinishedAt = DateTime.UtcNow;
    }
}
