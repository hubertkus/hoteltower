using Book.Data;
using Microsoft.EntityFrameworkCore;

namespace Room.Models;

public static class SeedData
{
    public static async Task<bool> EnsurePopulated(IRoomRepository roomRepository,BookDbContext bookDbContext)
    {
        await bookDbContext.Database.MigrateAsync();

        if (await bookDbContext.Rooms.AnyAsync())
           return false;

        var rooms=roomRepository.GetRooms();
        
        await bookDbContext.AddRangeAsync(rooms);
        await bookDbContext.SaveChangesAsync();

        return true;
    }
}