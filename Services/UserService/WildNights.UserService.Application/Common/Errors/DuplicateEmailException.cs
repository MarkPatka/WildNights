using System.Net;

namespace WildNights.UserService.Application.Common.Errors;

public class DuplicateEmailException : 
    Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Invalid Credentials";
}
