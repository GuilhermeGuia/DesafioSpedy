using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Infrastructure.Data.Seed;
using DesafioSpedy.Infrastructure.DataAccess.Seed;

namespace DesafioSpedy.Infrastructure.DataAccess;

public static class DbInitializer
{
    public static async Task Seed(
            DesafioSpedyDbContext _db,
            IPasswordEncryptor passwordEncryptor)
    {
        await UserSeed.SeedAsync(_db, passwordEncryptor);
        await TicketSeed.SeedAsync(_db);
    }
}