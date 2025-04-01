using FluentValidation;
using MediatR;
using WildNights.UserService.Application.Authentication.Commands.Register;
using WildNights.UserService.Application.Authentication.Common;
using WildNights.UserService.Domain.Common.Errors.Models;

namespace WildNights.UserService.Application.Common.Behaviors;

public class ValidateRegisterCommandBehavior
    : IPipelineBehavior<RegisterCommand, AuthenticationResult>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator;
    }

    public async Task<AuthenticationResult> Handle(
        RegisterCommand request, 
        RequestHandlerDelegate<AuthenticationResult> next, 
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator
            .ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var context = new ValidationContext<RegisterCommand>(request);

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
                $"One or more errors occured while {nameof(RegisterCommand)} validation\n" +
                $"For more informations see \"Errors\":", 
                System.Net.HttpStatusCode.BadRequest, 
                errors);
        }        
        return await next();
    }
}
