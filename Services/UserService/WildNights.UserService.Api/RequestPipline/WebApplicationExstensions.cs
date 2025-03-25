using WildNights.UserService.Api.Common.ModulesConfiguration;

namespace WildNights.UserService.Api.RequestPipline;

public static class WebApplicationExstensions
{
    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.MapEndpoints();
        app.UseHttpsRedirection();
        app.UseExceptionHandler("/error");   
        
        return app;
    }
}
