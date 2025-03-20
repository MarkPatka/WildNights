namespace WildNights.UserService.Api.RequestPipline;

public static class WebApplicationExstensions
{
    public static WebApplication UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        

        return app;
    }
}
