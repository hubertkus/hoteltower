using BuildingBlocks.Exception;

namespace Room.Exceptions;

public class InvalidReserveException : CustomException
{
    public InvalidReserveException(string message) : base(message)
    { }
}