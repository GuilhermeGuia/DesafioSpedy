namespace DesafioSpedy.Domain.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
