using System.Net;
using WildNights.UserService.Domain.Common.Errors.Abstract;

namespace WildNights.UserService.Domain.Common.Errors.Models;

public sealed class AuthenticationErrors(int id, string name, string errorMessage, HttpStatusCode statusCode, string? description = null)
    : Error(id, name, errorMessage, statusCode, description)
{
    public static readonly AuthenticationErrors DUPLICATE_EMAIL = new(1, nameof(DUPLICATE_EMAIL), "Invalid Credentials", HttpStatusCode.Conflict);
    public static readonly AuthenticationErrors USER_EXISTS = new(2, nameof(USER_EXISTS), "Invalid Credentials", HttpStatusCode.Conflict);
    public static readonly AuthenticationErrors USER_NOT_EXIST = new(3, nameof(USER_NOT_EXIST), "Invalid Credentials", HttpStatusCode.Conflict);
    public static readonly AuthenticationErrors INVALID_CREDENTIALS = new(4, nameof(INVALID_CREDENTIALS), "Invalid Credentials", HttpStatusCode.Conflict);
}

