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
    public async Task<Booking?> GetByBookingAsync(Guid RoomId,DateOnly From,DateOnly To, CancellationToken cancellationToken)
    {
        return await context.Bookings.FirstOrDefaultAsync(b => b.RoomId == RoomId && (b.To <= From || b.From >= To), cancellationToken);
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