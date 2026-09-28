using BuildingBlocks.Exception;

namespace User.Exceptions;

public class InvalidEmailException : BadRequestException
{
    public InvalidEmailException(string email) : base($"User Email: '{email}' is invalid")
    { }
}