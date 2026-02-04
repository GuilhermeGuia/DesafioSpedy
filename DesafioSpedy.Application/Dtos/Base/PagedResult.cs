namespace DesafioSpedy.Application.Dtos.Base;

public class PagedResult<T>
{
    public List<T> Items { get; set; } = [];
    public int Total { get; set; }
}