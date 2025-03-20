namespace WildNights.UserService.Api.Common.Errors;

public class NotFoundExcepton(string message) 
    : ServiceException(StatusCodes.Status404NotFound, message)
{
     
}