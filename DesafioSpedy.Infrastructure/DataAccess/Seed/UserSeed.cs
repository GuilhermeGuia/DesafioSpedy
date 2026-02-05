using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess.Seed;

public static class UserSeed
{
    public static async Task SeedAsync(
        DesafioSpedyDbContext db,
        IPasswordEncryptor passwordEncryptor)
    {
        if (await db.User.AnyAsync())
            return;

        var users = new List<User>
        {
            new(
                Guid.NewGuid(),
                "Admin",
                "admin@admin.com",
                passwordEncryptor.Hash("123456")
            ),
            new(Guid.NewGuid(), "User 1", "user1@mail.com", passwordEncryptor.Hash("123456")),
            new(Guid.NewGuid(), "User 2", "user2@mail.com", passwordEncryptor.Hash("123456")),
            new(Guid.NewGuid(), "User 3", "user3@mail.com", passwordEncryptor.Hash("123456")),
            new(Guid.NewGuid(), "User 4", "user4@mail.com", passwordEncryptor.Hash("123456")),
            new(Guid.NewGuid(), "User 5", "user5@mail.com", passwordEncryptor.Hash("123456"))
        };

        await db.User.AddRangeAsync(users);
        await db.SaveChangesAsync();
    }
}