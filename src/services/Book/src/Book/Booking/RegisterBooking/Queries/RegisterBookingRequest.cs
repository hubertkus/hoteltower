
namespace Booking.RegisterBooking.Queries;

public record RegisterBookingRequest
{
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public DateOnly From { get; set; }
    public DateOnly To { get; set; }
}