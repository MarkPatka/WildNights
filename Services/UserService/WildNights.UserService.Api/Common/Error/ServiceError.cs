using System.Net;

namespace WildNights.UserService.Api.Common.Error;

[Serializable]
public class ServiceError : Exception
{
    private readonly int statusCode;
    private readonly string message;

    public ServiceError(int statusCode, string message)
        : base() 
    {
        this.statusCode = statusCode;
        this.message = message;
    }

    public HttpStatusCode StatusCode =>
        Enum.IsDefined(typeof(HttpStatusCode), statusCode)
            ? (HttpStatusCode)statusCode
            : HttpStatusCode.Conflict;

    public string ErrorMessage => message;
}
