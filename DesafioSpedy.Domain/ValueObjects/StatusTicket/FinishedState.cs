using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Domain.ValueObjects.StatusTicket;

public class FinishedState : ITicketState
{
    public ETicketStatus Status => ETicketStatus.Finished;

    public ITicketState Avancar()
    {
        throw new InvalidOperationException(
            "Ticket finalizado não pode sofrer alterações"
        );
    }
}
