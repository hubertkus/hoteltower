
using BuildingBlocks.Exception;

namespace Booking.Exceptions;

public class RegisterBookingFaultException : DbEntryFaultException
{
    public RegisterBookingFaultException(string name, System.Exception exception) :
    base($"Error '{name}' stacktrace\n {exception.StackTrace}")
    { }
}