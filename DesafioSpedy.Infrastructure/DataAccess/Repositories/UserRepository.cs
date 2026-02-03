using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess.Repositories;

public class UserRepository(DesafioSpedyDbContext _db) : IUserRepository 
{
    public async Task<User?> GetByEmail(string email)
    {
        return await _db.User.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetById(Guid Id)
    {
        return await _db.User.FindAsync(Id);
    }
}
