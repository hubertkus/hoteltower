using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.EFCore;
public abstract class AppDbContextBase : DbContext,IDbContext
{
 public AppDbContextBase(DbContextOptions<AppDbContextBase> options) : base(options);
}