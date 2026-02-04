namespace DesafioSpedy.Application.Dtos.Ticket;

public class GetTicketFilterDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 1;
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string AssignedUserId { get; set; } = string.Empty;
    public string Search { get; set; } = string.Empty;
}
