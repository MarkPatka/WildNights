using System.Net;
using WildNights.UserService.Domain.Common.Errors.Abstract;

namespace WildNights.UserService.Domain.Common.Errors.Models;

public class ValidationError(string message, HttpStatusCode httpStatusCode, IReadOnlyDictionary<string, string[]> errorsDictionary) 
    : Error(nameof(ValidationError), message)
{
    public IReadOnlyDictionary<string, string[]> Errors => errorsDictionary;

    public HttpStatusCode HttpStatusCode => httpStatusCode;

    public List<Exception> Flatten() => 
        [.. Errors.Values.SelectMany(mess => mess.Select(ex => new Exception(ex)))];
}
