using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess;

public static class DbInitializer
{
    public static async Task Seed(
            DesafioSpedyDbContext _db,
            IPasswordEncryptor passwordEncryptor)
    {
        if (await _db.User.AnyAsync())
            return;

        var adminUser = new User(
            id: Guid.NewGuid(),
            name: "Admin",
            email: "admin@admin.com",
            passwordHash: passwordEncryptor.Hash("123456")
        );

        _db.User.Add(adminUser);
        await _db.SaveChangesAsync();
    }
}