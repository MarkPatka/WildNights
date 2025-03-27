using System.Net;

namespace WildNights.UserService.Domain.Common.Errors.Abstract;

public abstract class Error : Exception
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string ErrorMessage { get; private set; }
    public HttpStatusCode StatusCode { get; }
    public string? Description { get; private set; } = null;

    protected Error(int id, string name, string errorMessage, HttpStatusCode statusCode, string? description = null) =>
        (Id, Name, ErrorMessage, StatusCode, Description) = (id, name, errorMessage, statusCode, description);    
}
