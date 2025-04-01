using System.Net;
using WildNights.UserService.Domain.Common.Errors.Abstract;

namespace WildNights.UserService.Domain.Common.Errors.Models;

public sealed class AuthenticationError(int id, string name, string errorMessage, HttpStatusCode statusCode, string? description = null)
    : Error(name, errorMessage)
{
    public int Id => id;
    public HttpStatusCode HttpStatusCode => statusCode;
    public string? Description => description;

    public static readonly AuthenticationError DUPLICATE_EMAIL = new(1, nameof(DUPLICATE_EMAIL), "Invalid Credentials", HttpStatusCode.Conflict);
    public static readonly AuthenticationError USER_EXISTS = new(2, nameof(USER_EXISTS), "Invalid Credentials", HttpStatusCode.Conflict);
    public static readonly AuthenticationError USER_NOT_EXIST = new(3, nameof(USER_NOT_EXIST), "Invalid Credentials", HttpStatusCode.Conflict);
    public static readonly AuthenticationError INVALID_CREDENTIALS = new(4, nameof(INVALID_CREDENTIALS), "Invalid Credentials", HttpStatusCode.Conflict);
}

