using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess.Repositories;

public class TicketRepository(DesafioSpedyDbContext _db) : ITicketRepository
{
    public async Task CreateAsync(Ticket ticket)
    {
        await _db.Ticket.AddAsync(ticket);
    }
    public IQueryable<Ticket> Query()
    {
        return _db.Ticket.AsQueryable();
    }
    public async Task<Ticket?> FindAsync(Guid Id)
    {
        return await _db.Ticket.FirstOrDefaultAsync(x => x.Id == Id);
    }
}
