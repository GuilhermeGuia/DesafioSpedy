namespace DesafioSpedy.Api.Poco;

public class JwtSettings
{
    public string Secret { get; init; } = string.Empty;
    public int ExpiresInMinutes { get; init; }
}
