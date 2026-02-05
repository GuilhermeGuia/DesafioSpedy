using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.ValueObjects.Ticket;

namespace DesafioSpedy.Application.Extensions;

public static class TicketQueryableExtensions
{
    public static IQueryable<Ticket> ApplyFilters(
    this IQueryable<Ticket> query,
    GetTicketFilterDto filters)
    {
        if (filters.Status.HasValue)
            query = query.Where(x => x.Status == (ETicketStatus)filters.Status);

        if (filters.Priority.HasValue)
            query = query.Where(x => x.Priority == (ETicketPriority)filters.Priority);

        if (!string.IsNullOrWhiteSpace(filters.ResponsableUserId))
            query = query.Where(x =>
                x.ResponsableUserId != null &&
                x.ResponsableUserId.ToString() == filters.ResponsableUserId);

        if (!string.IsNullOrWhiteSpace(filters.Search))
            query = query.Where(x =>
                x.Title.ToLower().Contains(filters.Search.ToLower()) ||
                x.Description.ToLower().Contains(filters.Search.ToLower()));

        return query;
    }
    public static IQueryable<Ticket> ApplyPaging(
    this IQueryable<Ticket> query,
    int page,
    int pageSize)
    {
        return query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}
