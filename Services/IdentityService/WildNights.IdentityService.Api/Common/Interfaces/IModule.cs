namespace WildNights.IdentityService.Api.Common.Interfaces;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
