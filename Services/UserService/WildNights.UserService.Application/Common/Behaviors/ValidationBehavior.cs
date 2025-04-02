using FluentValidation;
using MediatR;
using WildNights.UserService.Application.Authentication.Commands.Register;
using WildNights.UserService.Domain.Common.Errors.Models;

namespace WildNights.UserService.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (_validator is null) 
            return await next();

        var validationResult = await _validator
            .ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = _validator
            .Validate(context).Errors
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values); ;

        if (errors.Count != 0)
        {
            throw new ValidationError(
                $"One or more errors occured while {nameof(RegisterCommand)} validation", 
                System.Net.HttpStatusCode.BadRequest, 
                errors);
        }        
        return await next();
    }
}
