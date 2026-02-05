using DesafioSpedy.Domain.ValueObjects.Ticket;
using Domain.States;
using DesafioSpedy.Exceptions.Base;

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
        Status = ETicketStatus.Open;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public ETicketStatus Status { get; private set; }
    public ETicketPriority Priority { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public Guid ResponsableUserId { get; private set; }
    public User Responsable { get; private set; }
    public Guid CreatorUserId { get; private set; }
    public User Creator { get; private set; }

    public void AvancarStatus()
    {
        var currentState = TicketStateFactory.GetState(Status);
        var nextState = currentState.Avancar();
        Status = nextState.Status;
        UpdateAt = DateTime.UtcNow;

        if (Status == ETicketStatus.Finished)
        {
            FinishedAt = DateTime.UtcNow;
        }
    }
    public void AtualizarDados(
        string title,
        string description,
        ETicketPriority priority,
        Guid responsableUserId)
    {
        if (Status == ETicketStatus.Finished )
            throw new UpdateStatusTicketException("Não é possível editar um ticket finalizado.");

        Title = title;
        Description = description;
        Priority = priority;
        ResponsableUserId = responsableUserId;
        UpdateAt = DateTime.UtcNow;
    }

    public void DeletarTicket()
    {
        if (Status == ETicketStatus.Finished)
            throw new DeleteTicketException("Ticket finalizado não pode sofrer alterações.");

        Status = ETicketStatus.Finished;
        IsDeleted = true;
        UpdateAt = DateTime.UtcNow;
        FinishedAt = DateTime.UtcNow;
    }
}
