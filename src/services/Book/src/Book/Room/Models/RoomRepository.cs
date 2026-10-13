
namespace Room.Models;

public class RoomRepository : IRoomRepository
{
    public List<Room> GetRooms()
    {
        List<Room> Rooms = new List<Room>();

        Rooms.Add(new Room("1", "Pokój 1 osobowy"));
        Rooms.Add(new Room("1", "Pokój 1 osobowy"));
        Rooms.Add(new Room("2", "Pokój 2 osobowy"));
        Rooms.Add(new Room("2", "Pokój 2 osobowy"));
        Rooms.Add(new Room("3", "Pokój 3 osobowy"));
        Rooms.Add(new Room("4", "Pokój 4 osobowy"));

        return Rooms;
    }
}