using BuildingBlocks.Exception;

namespace Bookings.Exceptions;

public class InvalidIsDeletedException : CustomException
{
    public InvalidIsDeletedException(string message) : base(message)
    { }
}