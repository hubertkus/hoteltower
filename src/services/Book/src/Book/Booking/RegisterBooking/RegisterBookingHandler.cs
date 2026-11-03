using System.Threading.Tasks.Dataflow;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Booking.Models;
using Booking.RegisterBooking.Commands;

namespace Booking.RegisterBooking;

public class RegisterBookingHandler : IRequestHandler<RegisterBookingCommand, RegisterBookingResult>
{
    private readonly IBookingRepository bookingRepository;
    public RegisterBookingHandler(IBookingRepository _bookingRepository)
    {
        bookingRepository = _bookingRepository;
    }
    public async Task<RegisterBookingResult> Handle(RegisterBookingCommand command, CancellationToken cancellationToken)
    {
        var userId = command.UserId;
        var roomId = command.RoomId;
        var from = command.From;
        var to = command.To;

        var entity = await bookingRepository.GetByBookingAsync(roomId, from, to, cancellationToken);

        if (entity == null)
        {
            var booking = new Booking.Models.Booking(userId, roomId, from, to);
            entity = await bookingRepository.AddBook(booking);
        }
        return new RegisterBookingResult() { Id = entity.Id };
    }
}