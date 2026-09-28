
using BuildingBlocks.Exception;

namespace User.Exceptions;

public class InvalidNameException : BadRequestException
{
    public InvalidNameException(string name) : base($"User Name: '{name}' is invalid")
    { }
}