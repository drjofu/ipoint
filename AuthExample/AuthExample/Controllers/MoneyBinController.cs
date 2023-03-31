using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  //[Authorize]
//  [AllowAnonymous]
  public class MoneyBinController : ControllerBase
  {
    private static double content = 99999999; // only for demo purposes!!!

    [HttpGet]
    [Authorize(Policy = "moneyBinR")]
    public ActionResult<double> Get()
    {
      return Ok(content);
    }

    [HttpPost]
    [Authorize(Policy = "moneyBinRW")]
    public ActionResult<double> Post(double transfer)
    {
      content += transfer;
      return Ok(content);
    }

  }
}
