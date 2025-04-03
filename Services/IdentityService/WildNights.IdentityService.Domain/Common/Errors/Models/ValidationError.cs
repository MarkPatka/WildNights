using System.Net;
using WildNights.IdentityService.Domain.Common.Errors.Abstract;

namespace WildNights.IdentityService.Domain.Common.Errors.Models;

public class ValidationError(string message, HttpStatusCode httpStatusCode, IReadOnlyDictionary<string, string[]> errorsDictionary) 
    : Error(ErrorType.VALIDATION, message)
{
    public IReadOnlyDictionary<string, string[]> Errors => errorsDictionary;

    public HttpStatusCode HttpStatusCode => httpStatusCode;

    public List<Exception> Flatten() => 
        [.. Errors.Values.SelectMany(mess => mess.Select(ex => new Exception(ex)))];
}
