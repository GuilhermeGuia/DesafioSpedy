using DesafioSpedy.Domain.Crypto;
using DesafioSpedy.Domain.Entities;

namespace DesafioSpedy.Infrastructure.DataAccess;

public static class DbInitializer
{
    public static void Seed(
            DesafioSpedyDbContext _db,
            IPasswordEncryptor passwordEncryptor)
    {
        if (_db.User.Any())
            return;

        var adminUser = new User(
            id: Guid.NewGuid(),
            name: "Admin",
            email: "admin@admin.com",
            passwordHash: passwordEncryptor.Hash("123456")
        );

        _db.User.Add(adminUser);
        _db.SaveChanges();
    }
}