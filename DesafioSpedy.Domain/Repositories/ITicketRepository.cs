using DesafioSpedy.Domain.Entities;
namespace DesafioSpedy.Domain.Repositories;

public interface ITicketRepository
{
    Task CreateTicket(Ticket ticket);
}
