using BuildingBlocks.Exception;

namespace Booking.Exceptions;

public class InvalidIsDeletedException : CustomException
{
    public InvalidIsDeletedException(string message) : base(message)
    { }
}