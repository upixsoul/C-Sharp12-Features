
using Castle.DynamicProxy;

namespace WebInterceptors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddSingleton<IReaderService>(_ =>
            {
                var proxyGenerator = new ProxyGenerator();
                var target = new ReaderService();
                var interceptor = new MethodInterceptor();
                return proxyGenerator.CreateInterfaceProxyWithTarget<IReaderService>(target, interceptor);
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext _) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.UseMiddleware<RequestInterceptorMiddleware>();

            app.Run();
        }
    }

    public class NotificationService
    {
        public virtual string Send(string message)
        {
            return $"Sending: {message}";
        }
    }

    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"[LOG] Calling {invocation.Method.Name}");
            invocation.Proceed();
            Console.WriteLine($"[LOG] Finished {invocation.Method.Name}");
        }
    }
}
