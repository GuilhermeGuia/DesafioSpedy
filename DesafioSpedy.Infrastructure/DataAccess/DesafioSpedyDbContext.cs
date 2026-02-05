using DesafioSpedy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioSpedy.Infrastructure.DataAccess;

public class DesafioSpedyDbContext : DbContext
{
    public DesafioSpedyDbContext(DbContextOptions<DesafioSpedyDbContext> options) : base(options) { }

    #region DBSETS
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasOne(t => t.Responsable)
                .WithMany()
                .HasForeignKey(t => t.ResponsableUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Creator)
                .WithMany()
                .HasForeignKey(t => t.CreatorUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioSpedyDbContext).Assembly);
    }
}
