using DesafioSpedy.Application.Dtos.Ticket;
using DesafioSpedy.Domain.Entities;

namespace DesafioSpedy.Application.Extensions;

public static class TicketQueryableExtensions
{
    public static IQueryable<Ticket> ApplyFilters(
    this IQueryable<Ticket> query,
    GetTicketFilterDto filters)
    {
        if (!string.IsNullOrWhiteSpace(filters.Status))
            query = query.Where(x => x.Status.ToString() == filters.Status);

        if (!string.IsNullOrWhiteSpace(filters.Priority))
            query = query.Where(x => x.Priority.ToString() == filters.Priority);

        if (!string.IsNullOrWhiteSpace(filters.AssignedUserId))
            query = query.Where(x =>
                x.AssignedUserId != null &&
                x.AssignedUserId.ToString() == filters.AssignedUserId);

        if (!string.IsNullOrWhiteSpace(filters.Search))
            query = query.Where(x =>
                x.Title.Contains(filters.Search) ||
                x.Description.Contains(filters.Search));

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
