using MediatR;

namespace Booking.RegisterBooking.Commands;

public record RegisterBookingCommand(Guid UserId, Guid RoomId, DateOnly From, DateOnly To) : IRequest<RegisterBookingResult>;