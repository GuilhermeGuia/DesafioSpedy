namespace DesafioSpedy.Application.Dtos.Ticket;

public class GetTicketFilterDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int? Status { get; set; }
    public int? Priority { get; set; }
    public string? ResponsableUserId { get; set; }
    public string? Search { get; set; }
}
