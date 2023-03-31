using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApiVersioning.Controllers
{
  [ApiController]
  [Route("c")]
  [ApiVersion("3.0")]
  [ApiVersion("2.0")]
  public class C3Controller : ControllerBase
  {
    [HttpGet]
    //[MapToApiVersion("2.0")]
    public string Get()
    {
      var apiVersion = HttpContext.GetRequestedApiVersion();
      return $"{this.GetType().Name} {apiVersion}";
    }

    //[HttpGet]
    //[MapToApiVersion("2.0")]
    //public string Get_v2()
    //{
    //  return "C3 v2";
    //}

  }
}
