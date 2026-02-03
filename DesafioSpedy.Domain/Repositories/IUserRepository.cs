using DesafioSpedy.Domain.Entities;

namespace DesafioSpedy.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(Guid id);
}
