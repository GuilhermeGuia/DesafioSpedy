using System.Security.Claims;
using DesafioSpedy.Domain.Http;
using Microsoft.AspNetCore.Http;

namespace DesafioSpedy.Infrastructure.Http;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor
                .HttpContext?
                .User?
                .FindFirst(ClaimTypes.NameIdentifier)
                ?.Value;

            if (string.IsNullOrWhiteSpace(userIdClaim))
                throw new InvalidOperationException("Usuário não autenticado");

            return Guid.Parse(userIdClaim);
        }
    }

    public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;
}
