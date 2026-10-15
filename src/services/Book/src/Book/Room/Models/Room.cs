using Room.Exceptions;
namespace Room.Models;

public class Room
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string ShortName { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public bool Reserved { get; private set; }
    private Room()
    { }
    public Room(string shortName, string name)
    {
        if (string.IsNullOrWhiteSpace(shortName))
            throw new InvalidShortNameException(shortName);

        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidNameException(name);

        ShortName = shortName;
        Name = name;
    }
    public void Reserve()
    {
        if (Reserved)
            throw new InvalidReserveException("Reservation already exists.");
        Reserved = true;
    }
    public void CancelReservation()
    {
        if (!Reserved)
            throw new InvalidReserveException("Reservation is possible.");
        Reserved = false;
    }
}