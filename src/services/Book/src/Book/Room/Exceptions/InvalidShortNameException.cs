using BuildingBlocks.Exception;

namespace Room.Exceptions;

public class InvalidShortNameException : BadRequestException
{
    public InvalidShortNameException(string email) : base("Room ShortName cannot be empty")
    { }
}