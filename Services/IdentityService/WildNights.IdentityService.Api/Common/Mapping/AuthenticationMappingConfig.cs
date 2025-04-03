using Mapster;
using WildNights.IdentityService.Application.Authentication.Commands.Register;
using WildNights.IdentityService.Application.Authentication.Common;
using WildNights.IdentityService.Application.Authentication.Queries.Login;
using WildNights.IdentityService.Contracts.Authentication;

namespace WildNights.IdentityService.Api.Common.Mapping;

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
