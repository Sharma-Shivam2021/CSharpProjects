
namespace MyFirstApp;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // before
        await context.Response.WriteAsync("From CustomMiddleware - Start\n");
        await next(context);
        //after
        await context.Response.WriteAsync("From CustomMiddleware - End\n");
    }
}

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<MyCustomMiddleware>();
    }
}

