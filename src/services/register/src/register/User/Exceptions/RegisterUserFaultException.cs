
using BuildingBlocks.Exception;

namespace User.Exceptions;

public class RegisterUserFaultException : DbEntryFaultException
{
    public RegisterUserFaultException(string name, System.Exception exception) :
    base($"User Name: '{name}' add error\n {exception.StackTrace}")
    { }
}