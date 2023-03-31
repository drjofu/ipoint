
namespace ModialExample.Services
{
  public class TimingService
  {
    private readonly ILogger<TimingService> logger;
    private Timer timer;

    public TimingService(ILogger<TimingService> logger)
    {
      this.logger = logger;
    }

    public void Start()
    {
      timer = new Timer(TimerTick, null, 1000, 1000);
    }

    private void TimerTick(object state)
    {
      logger.LogInformation("Timing service: {time}",DateTime.Now);
    }
  }
}
