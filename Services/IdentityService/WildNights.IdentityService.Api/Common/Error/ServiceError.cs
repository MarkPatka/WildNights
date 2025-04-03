using System.Net;
using WildNights.IdentityService.Domain.Common.Errors.Abstract;

namespace WildNights.IdentityService.Api.Common.Error;

[Serializable]
public class ServiceError(int statusCode, string message, ErrorType type, string? comment = null) 
    : Exception(message)
{
    private readonly int statusCode = statusCode;
    private readonly string? comment = comment;
    private readonly ErrorType errorType = type;


    public HttpStatusCode StatusCode =>
        Enum.IsDefined(typeof(HttpStatusCode), statusCode)
            ? (HttpStatusCode)statusCode
            : HttpStatusCode.Conflict;

    public string? Comment => comment;
    public ErrorType ErrorType => errorType;
}
