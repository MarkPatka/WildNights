using WildNights.UserService.Api.Common.ModulesConfiguration;
using WildNights.UserService.Application;
using WildNights.UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.RegisterModules();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
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
    app.Run();
}
