namespace WildNights.UserService.Domain.Common.Errors.Abstract;

public abstract class Error(string name, string message) 
    : Exception(message)
{
    public string Name { get; private set; } = name;
}
