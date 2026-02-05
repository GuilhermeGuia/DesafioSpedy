using DesafioSpedy.Domain.Entities;
using DesafioSpedy.Domain.ValueObjects.Ticket;
using DesafioSpedy.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.Data.Seed;

public static class TicketSeed
{
    public static async Task SeedAsync(DesafioSpedyDbContext db)
    {
        if (await db.Ticket.AnyAsync())
            return;

        var users = await db.User.ToListAsync();

        if (users.Count < 2)
            return;

        var creator = users.First();
        var responsible = users.Last();

        var tickets = new List<Ticket>
        {
            new(
                title: "Erro ao logar",
                description: "Usuário não consegue autenticar",
                priority: ETicketPriority.High,
                responsableUserId: responsible.Id,
                creatorUserId: creator.Id
            ),
            new(
                title: "Tela lenta",
                description: "Sistema demorando para responder",
                priority: ETicketPriority.Medium,
                responsableUserId: responsible.Id,
                creatorUserId: creator.Id
            ),
            new(
                title: "Sugestão de melhoria",
                description: "Adicionar filtro por prioridade",
                priority: ETicketPriority.Low,
                responsableUserId: responsible.Id,
                creatorUserId: creator.Id
            )
        };

        await db.Ticket.AddRangeAsync(tickets);
        await db.SaveChangesAsync();
    }
}
