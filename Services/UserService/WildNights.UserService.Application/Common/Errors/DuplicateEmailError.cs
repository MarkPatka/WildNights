using System.Net;

namespace WildNights.UserService.Application.Common.Errors;

public class DuplicateEmailError : Exception, IServiceError 
{
    public string ErrorMessage => "Invalid Credentials";
    public int StatusCode => (int)HttpStatusCode.Conflict;
    public DuplicateEmailError() : base() { }
}
