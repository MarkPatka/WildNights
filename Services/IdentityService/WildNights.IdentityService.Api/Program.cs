using WildNights.IdentityService.Api.MiddlewarePipeline;
using WildNights.IdentityService.Application;
using WildNights.IdentityService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .RegisterRequestPipeline()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.ConfigureWebApplication();
    app.Run();
}
