namespace DesafioSpedy.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; }
    public DateTime DeleteAt { get; set; }
}
