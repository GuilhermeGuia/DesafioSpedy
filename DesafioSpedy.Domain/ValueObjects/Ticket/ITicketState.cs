namespace DesafioSpedy.Domain.ValueObjects.Ticket;

public interface ITicketState
{
    ETicketStatus Status { get; }
    ITicketState Avancar();
}
