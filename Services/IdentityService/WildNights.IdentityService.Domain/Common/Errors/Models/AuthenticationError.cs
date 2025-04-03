using System.Net;
using WildNights.IdentityService.Domain.Common.Errors.Abstract;

namespace WildNights.IdentityService.Domain.Common.Errors.Models;

public sealed class AuthenticationError(string errorMessage, HttpStatusCode statusCode, string? comment = null)
    : Error(ErrorType.AUTHENTICATION, errorMessage)
{
    public HttpStatusCode HttpStatusCode => statusCode;
    public string? Comment => comment;
}

