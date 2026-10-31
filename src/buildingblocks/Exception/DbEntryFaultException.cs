namespace BuildingBlocks.Exception;

public class DbEntryFaultException : CustomException
{
    public DbEntryFaultException(string message, System.Exception exception) : base(message, exception)
    { }
    public DbEntryFaultException(string message) : base(message)
    { }
}