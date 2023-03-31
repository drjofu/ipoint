using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModialExample.Models;
using Shared;

namespace ModialExample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ContinentController : ControllerBase
  {
    private readonly World world;

    public ContinentController(World world)
    {
      this.world = world;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Continent>> Get()
    {
      return Ok(world.GetContinents());
    }
  }
}
