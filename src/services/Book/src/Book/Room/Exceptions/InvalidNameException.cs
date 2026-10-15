
using BuildingBlocks.Exception;

namespace Room.Exceptions;

public class InvalidNameException : BadRequestException
{
    public InvalidNameException(string name) : base("Room Name cannot be empty")
    { }
}