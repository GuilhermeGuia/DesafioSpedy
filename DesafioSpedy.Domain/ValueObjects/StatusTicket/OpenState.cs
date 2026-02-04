using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Domain.ValueObjects.StatusTicket;

public class OpenState : ITicketState
{
    public ETicketStatus Status => ETicketStatus.Open;

    public ITicketState Avancar()
    {
        return new InProgressState();
    }
}
