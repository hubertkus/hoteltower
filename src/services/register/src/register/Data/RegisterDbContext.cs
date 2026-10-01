using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using User.Models;

namespace Register.Data;

public sealed class RegisterDbContext : AppDbContextBase
{
    public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
    { }

    public DbSet<User.Models.User> Users => Set<User.Models.User>();
}
