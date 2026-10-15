using System.Net;

namespace BuildingBlocks.Exception;

public class CustomException : System.Exception
{
    public HttpStatusCode StatusCode { get; }
    public int? Code { get; }

    public CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, int? code = null) : base(message)
    {
        StatusCode = statusCode;
        Code = code;
    }
    public CustomException(string message, System.Exception exception) : base(message,exception)
    { }
    public CustomException(string message) : base(message)
    { }

}