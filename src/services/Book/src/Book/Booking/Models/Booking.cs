using Bookings.Exceptions;
using BuildingBlocks.EFCore.Auditing;

namespace Booking.Models;

public class Booking : IAuditable
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public bool IsDeleted { get; private set; } = false;
    public Guid UserId { get; private set; }
    public Guid RoomId { get; private set; }
    public DateOnly From { get; private set; }
    public DateOnly To { get; private set; }
    public int Days { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    private Booking()
    { }
    public Booking(Guid userId, Guid roomId, DateOnly from, DateOnly to)
    {
        UserId = userId;
        RoomId = roomId;
        From = from;
        To = to;
        Days = to.DayNumber - from.DayNumber;
    }
    public void Deleted()
    {
        if (IsDeleted)
            throw new InvalidIsDeletedException("Booking is deleted.");
        IsDeleted = true;
    }
    public void UnDeleted()
    {
        if (!IsDeleted)
            throw new InvalidIsDeletedException("Booking is undeleted.");
        IsDeleted = false;
    }
}