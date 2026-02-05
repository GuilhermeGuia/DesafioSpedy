using DesafioSpedy.Domain.ValueObjects.StatusTicket;
using DesafioSpedy.Domain.ValueObjects.Ticket;
using DesafioSpedy.Exceptions.Base;

namespace Domain.States;

public static class TicketStateFactory
{
    public static ITicketState GetState(ETicketStatus status)
    {
        return status switch
        {
            ETicketStatus.Open => new OpenState(),
            ETicketStatus.InProgress => new InProgressState(),
            ETicketStatus.Finished => new FinishedState(),
            _ => throw new AvancarStatusTicketException($"Status '{status}' não é válido.")
        };
    }
}