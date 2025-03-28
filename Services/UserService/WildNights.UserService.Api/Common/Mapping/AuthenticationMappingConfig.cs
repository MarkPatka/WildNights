using Mapster;
using WildNights.UserService.Application.Authentication.Commands.Register;
using WildNights.UserService.Application.Authentication.Common;
using WildNights.UserService.Application.Authentication.Queries.Login;
using WildNights.UserService.Contracts.Authentication;

namespace WildNights.UserService.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
        
    }
}
