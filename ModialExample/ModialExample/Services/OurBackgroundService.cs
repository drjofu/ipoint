namespace ModialExample.Services
{
  public class OurBackgroundService : BackgroundService
  {
    private readonly TimingService timingService;

    public OurBackgroundService(TimingService timingService)
    {
      this.timingService = timingService;
    }
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
      timingService.Start();
      return Task.CompletedTask;
    }
  }

  public abstract class BackgroundServiceSelfImplemented : IHostedService
  {
    private CancellationTokenSource cts;
    protected abstract Task ExecuteAsync(CancellationToken stoppingToken);

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      cts = new CancellationTokenSource();
      await ExecuteAsync(cts.Token);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      cts.Cancel();
      return Task.CompletedTask;
    }
  }

}
