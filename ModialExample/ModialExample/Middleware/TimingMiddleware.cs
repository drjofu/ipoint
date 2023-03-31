using System.Diagnostics;

namespace ModialExample.Middleware
{
  public class TimingMiddleware
  {
    private readonly ILogger<TimingMiddleware> logger;
    private readonly RequestDelegate next;

    public TimingMiddleware(ILogger<TimingMiddleware>logger, RequestDelegate next)
    {
      this.logger = logger;
      this.next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      Stopwatch sw = new Stopwatch();
      sw.Start();
      //try
      //{
       
      await next(httpContext);

      //}
      //catch (Exception)
      //{
      //}    
      
      sw.Stop();
      logger.LogInformation("Elapsed time: {time}", sw.ElapsedMilliseconds);
    }
  }

  public static class TimingMiddlewareExtionsions
  {
    public static IApplicationBuilder UseTiming(this IApplicationBuilder app)
    {
      return app.UseMiddleware<TimingMiddleware>();
    }
  }
}
