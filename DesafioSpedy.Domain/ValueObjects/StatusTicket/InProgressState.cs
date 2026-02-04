using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Domain.ValueObjects.StatusTicket;

public class InProgressState : ITicketState
{
    public ETicketStatus Status => ETicketStatus.InProgress;

    public ITicketState Avancar()
    {
        return new FinishedState();
    }
}
