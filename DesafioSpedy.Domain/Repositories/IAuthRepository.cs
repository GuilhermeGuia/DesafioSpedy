using DesafioSpedy.Domain.Entities;

namespace DesafioSpedy.Domain.Repositories;

public interface IAuthRepository
{
    Task<User?> GetByEmail(string email);
}
