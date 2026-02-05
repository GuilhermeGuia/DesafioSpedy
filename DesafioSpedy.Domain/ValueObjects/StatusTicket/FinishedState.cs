using DesafioSpedy.Domain.ValueObjects.Ticket;
using DesafioSpedy.Exceptions.Base;

namespace DesafioSpedy.Domain.ValueObjects.StatusTicket;

public class FinishedState : ITicketState
{
    public ETicketStatus Status => ETicketStatus.Finished;

    public ITicketState Avancar()
    {
        throw new AvancarStatusTicketException(
            "Ticket finalizado não pode sofrer alterações"
        );
    }
}
