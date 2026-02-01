namespace DesafioSpedy.Domain.Authorization;

public interface IJwtGenerator
{
    string GenerateToken(Guid userId, string userName, string userEmail);
}
