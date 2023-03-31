using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [ApiVersion("1.1")]
  [Route("c")]
  public class C1Controller:ControllerBase
  {
    [HttpGet]
    public string Get()
    {
      var apiVersion = HttpContext.GetRequestedApiVersion();
      return $"{this.GetType().Name} {apiVersion}";
    }
  }
}
