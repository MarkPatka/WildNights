using WildNights.IdentityService.Domain.Common.Errors.Abstract;

namespace WildNights.IdentityService.Api.Common.Error;

[Serializable]
public class AggregateError(int statusCode, ErrorType errorType, List<Exception> errors) 
    : ServiceError(statusCode, string.Join(" ", errors.Select(err => err.Message)), errorType)
{
    private readonly int errorsCount = errors.Count;
    public int ErrorsCount => errorsCount;
}
