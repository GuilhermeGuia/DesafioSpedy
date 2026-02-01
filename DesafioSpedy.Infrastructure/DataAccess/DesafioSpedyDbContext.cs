using DesafioSpedy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess;

public class DesafioSpedyDbContext : DbContext
{
    public DesafioSpedyDbContext(DbContextOptions<DesafioSpedyDbContext> options) : base(options) { }

    #region DBSETS
        public virtual DbSet<User> User { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioSpedyDbContext).Assembly);
    }
}
