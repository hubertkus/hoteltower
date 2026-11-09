using Microsoft.EntityFrameworkCore;
using Book.Data;
using Booking.Exceptions;

namespace Booking.Models;

public class EFBookingRepository : IBookingRepository
{
    private readonly BookDbContext context;

    public EFBookingRepository(BookDbContext _context)
    {
        context = _context;
    }
    public async Task<bool> GetByBookingAsync(Guid RoomId, DateOnly From, DateOnly To, CancellationToken cancellationToken)
    {
        var booking = await context.Bookings.FirstOrDefaultAsync(b => b.RoomId == RoomId && (b.To <= From || b.From >= To), cancellationToken);
        return booking != null;
    }
    public async Task<Booking> AddBook(Booking booking)
    {
        try
        {
            await context.AddAsync(booking);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new RegisterBookingFaultException("Błąd zapisu rezerwacji", ex);
        }
        return booking;
    }
}