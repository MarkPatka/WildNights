using System.Net;
using WildNights.UserService.Application.Common.Errors;

namespace WildNights.UserService.Api.Common.Errors;

public class ServiceException(HttpStatusCode statusCode, string message) 
    : Exception, IServiceException
{
    public HttpStatusCode StatusCode => statusCode;

    public string ErrorMessage => message;
}
