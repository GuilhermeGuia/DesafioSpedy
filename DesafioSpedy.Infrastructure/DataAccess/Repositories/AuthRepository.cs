using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess.Repositories;

public class AuthRepository(DesafioSpedyDbContext _db) : IAuthRepository 
{
    public Task<User?> GetByEmail(string email)
    {
        return _db.User.FirstOrDefaultAsync(u => u.Email == email);
    }
}
