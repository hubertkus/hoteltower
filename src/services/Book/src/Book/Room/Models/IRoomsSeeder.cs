namespace Room.Models;

public interface IRoomsSeeder
{
    Task<bool> EnsurePopulated();
}