using Microsoft.AspNetCore.Mvc;

namespace FirstWebApiExample.Controllers
{
  [Route("[controller]")]
  public class SampleController : IDisposable
  {

    public string Get()
    {
      return "Good morning!";
    }

    [HttpGet("hello")]
    public string SayHello(string name)
    {
      return $"Hello {name}";
    }

    [HttpGet("add")]
    public int Add(int a, int b)
    {
      return a + b;
    }

    public void Dispose()
    {
      // clean up if needed
    }

  }
}
