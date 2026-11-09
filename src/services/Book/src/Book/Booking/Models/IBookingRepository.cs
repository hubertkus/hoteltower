
namespace Booking.Models;

public interface IBookingRepository
{
    Task<bool> GetByBookingAsync(Guid RoomId, DateOnly From, DateOnly To, CancellationToken cancellationToken);
    Task<Booking> AddBook(Booking booking);
}