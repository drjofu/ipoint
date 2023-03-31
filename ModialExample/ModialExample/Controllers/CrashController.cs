using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModialExample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CrashController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get()
    {
      throw new ApplicationException("ooohhhh...");
    }
  }
}
