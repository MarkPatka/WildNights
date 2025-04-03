using WildNights.IdentityService.Api.Common.ModulesConfiguration;

namespace WildNights.IdentityService.Api.MiddlewarePipeline;

public static class WebApplicationExstensions
{
    public static WebApplication ConfigureWebApplication(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapEndpoints()
           .UseHttpsRedirection()
           .UseExceptionHandler()
           ;

        return app;
    }
}


