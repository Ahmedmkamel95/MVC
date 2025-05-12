public class HelloWorldMiddleware
{
    private readonly RequestDelegate _next;

    public HelloWorldMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Only show "Hello World" on the root path (optional)
        if (context.Request.Path == "/hello")
        {
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync("Hello World");
        }
        else
        {
            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
