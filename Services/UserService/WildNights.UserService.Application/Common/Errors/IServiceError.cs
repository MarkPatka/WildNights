namespace WildNights.UserService.Application.Common.Errors;

public interface IServiceError 
{
    public string ErrorMessage { get; }
    public int StatusCode { get; }
}
