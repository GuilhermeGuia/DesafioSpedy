namespace DesafioSpedy.Domain.Entities;

public class User : EntityBase
{
    protected User() { }
    public User(Guid id, string name, string email, string passwordHash)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
}
