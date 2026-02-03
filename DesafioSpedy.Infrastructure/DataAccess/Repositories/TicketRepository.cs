using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.Repositories;

namespace DesafioSpedy.Infrastructure.DataAccess.Repositories;

public class TicketRepository(DesafioSpedyDbContext _db) : ITicketRepository
{
    public async Task CreateTicket(Ticket ticket)
    {
        await _db.Ticket.AddAsync(ticket);
    }
}
