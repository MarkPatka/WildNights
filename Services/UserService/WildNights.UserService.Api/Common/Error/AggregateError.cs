namespace WildNights.UserService.Api.Common.Error;

[Serializable]
public class AggregateError : ServiceError
{
    private readonly int errorsCount;

    public AggregateError(
        string message,
        List<Exception> errors,
        int statusCode)
        : base(
            statusCode,
            string.Join(";\n", errors.Select(err => err.Message)))
    {
        this.errorsCount = errors.Count;
    }

    public int ErrorsCount => errorsCount;
}
