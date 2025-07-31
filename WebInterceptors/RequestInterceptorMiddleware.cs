
namespace WebInterceptors
{
    public class RequestInterceptorMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestInterceptorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Before request processing
            Console.WriteLine($"Incoming Request: {context.Request.Method} {context.Request.Path}");

            // Call the next middleware in the pipeline
            await _next(context);

            // After response processing
            Console.WriteLine($"Outgoing Response: {context.Response.StatusCode}");
        }
    }

}