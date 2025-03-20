using WildNights.UserService.Api.Common.ModulesConfiguration;
using WildNights.UserService.Api.RequestPipline;
using WildNights.UserService.Application;
using WildNights.UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.RegisterModules();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.RegisterRequestPipeline();

}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.MapEndpoints();
    app.UseGlobalErrorHandling();
    app.Run();
}
