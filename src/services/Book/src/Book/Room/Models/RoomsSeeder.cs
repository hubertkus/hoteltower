using Book.Data;
using Microsoft.EntityFrameworkCore;

namespace Room.Models;

public class RoomsSeeder : IRoomsSeeder
{
    private readonly IRoomRepository roomRepository;
    private readonly BookDbContext bookDbContext;

    public RoomsSeeder(IRoomRepository _roomRepository, BookDbContext _bookDbContext)
    {
        roomRepository = _roomRepository;
        bookDbContext = _bookDbContext;
    }

    public async Task<bool> EnsurePopulated()
    {
        await bookDbContext.Database.MigrateAsync();

        if (await bookDbContext.Rooms.AnyAsync())
            return false;

        var rooms = roomRepository.GetRooms();

        await bookDbContext.AddRangeAsync(rooms);
        await bookDbContext.SaveChangesAsync();

        return true;
    }
}