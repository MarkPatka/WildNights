using WildNights.UserService.Api.RequestPipline;
using WildNights.UserService.Application;
using WildNights.UserService.Infrastructure;

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
