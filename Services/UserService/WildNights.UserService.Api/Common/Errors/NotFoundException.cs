using System.Net;

namespace WildNights.UserService.Api.Common.Errors;

public class NotFoundExcepton(string message) 
    : ServiceException(HttpStatusCode.Conflict, message)
{
     
}