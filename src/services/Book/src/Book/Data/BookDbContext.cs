using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using Room.Models;

namespace Book.Data;

public sealed class BookDbContext : AppDbContextBase
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    { }

    public DbSet<Room.Models.Room> Rooms => Set<Room.Models.Room>();
}
