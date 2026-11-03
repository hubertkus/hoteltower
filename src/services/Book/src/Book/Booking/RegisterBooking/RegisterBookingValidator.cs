
using FluentValidation;
using Booking.RegisterBooking.Commands;

namespace Booking.RegisterBooking;

public class RegisterBookingValidator : AbstractValidator<RegisterBookingCommand>
{
    public RegisterBookingValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty).WithMessage("UserId must be a valid GUID");
        RuleFor(x => x.RoomId).NotEqual(Guid.Empty).WithMessage("RoomId must be a valid GUID");
        RuleFor(x => x.From).LessThan(x => x.To).WithMessage("From date must be before To date");
    }
}