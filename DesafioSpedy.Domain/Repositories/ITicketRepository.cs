using DesafioSpedy.Domain.Entities;
namespace DesafioSpedy.Domain.Repositories;

public interface ITicketRepository
{
    Task CreateAsync(Ticket ticket);
    IQueryable<Ticket> Query();
    Task<Ticket?> FindAsync(Guid Id);
}
