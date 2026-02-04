namespace DesafioSpedy.Domain.Http;

public interface ICurrentUser
{
    Guid UserId { get; }
    bool IsAuthenticated { get; }
}