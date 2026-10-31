using Microsoft.EntityFrameworkCore;
using BuildingBlocks.EFCore.Auditing;

namespace BuildingBlocks.EFCore;
public abstract class AppDbContextBase : DbContext, IDbContext
{
    public AppDbContextBase(DbContextOptions options) : base(options)
    { }
    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditFields()
    {
        var entries = ChangeTracker
            .Entries<IAuditable>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                // Nie zmieniaj daty utworzenia przy aktualizacji.
                entry.Property(x => x.CreatedAt).IsModified = false;
            }
        }
    }
}