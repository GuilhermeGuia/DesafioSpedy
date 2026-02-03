namespace DesafioSpedy.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdateAt { get; protected set; }
    public DateTime? DeleteAt { get; protected set; }
}
