using WildNights.UserService.Api.Common.ModulesConfiguration;

namespace WildNights.UserService.Api.RequestPipline;

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

    //public static WebApplication AddGlobalErrorHandling(this WebApplication app)
    //{
    //    app.UseExceptionHandler(exceptionHandlerApp =>
    //        exceptionHandlerApp.Run(async httpContext =>
    //        {
    //            var pds = httpContext.RequestServices.GetService<IProblemDetailsService>();

    //            if (pds == null || !await pds.TryWriteAsync(new() { HttpContext = httpContext }))
    //            {
    //                await httpContext.Response.WriteAsync("Fallback: An error occurred.");
    //            }
    //        }));
        
    //    return app;
    //}
}


