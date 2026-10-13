using Book.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Room.Models;

public static class SeedData
{
    public static async void EnsurePopulated(IServiceProvider serviceProvider, IRoomRepository roomRepository)
    {
        BookDbContext bookDbContext = serviceProvider.GetRequiredService<BookDbContext>();

        bookDbContext.Database.Migrate();
        if (!bookDbContext.Rooms.Any())
        {
            foreach (var room in roomRepository.GetRooms())
            {
                bookDbContext.AddRange(room);
            }
        }
        await bookDbContext.SaveChangesAsync();
    }
}