using DesafioSpedy.Domain.Repositories;

namespace DesafioSpedy.Infrastructure.DataAccess.Repositories;

public class UnitOfWork(DesafioSpedyDbContext _db) : IUnitOfWork, IDisposable
{
    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
    public void Dispose()
    {
        _db.Dispose();
    }
}
