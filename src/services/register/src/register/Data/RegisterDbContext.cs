using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using User.Models;

namespace Register.Data;

public sealed class RegisterDbContext : AppDbContextBase
{
    public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
    { }

    public DbSet<User.Models.User> Users => Set<User.Models.User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User.Models.User>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.ComplexProperty(
                x => x.Name,
                name =>
                {
                       name.Property(x => x.Value)
                           .HasColumnName("Name")
                           .IsRequired();
                   });

            builder.ComplexProperty(
                x => x.Email,
                email =>
                {
                       email.Property(x => x.Value)
                           .HasColumnName("Email")
                           .IsRequired();
                   });
        });
    }
}
