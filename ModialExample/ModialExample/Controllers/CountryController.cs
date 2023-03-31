using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModialExample.Models;
using Shared;

namespace ModialExample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CountryController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Country>>Get(string continentId, [FromServices]World world)
    {
      var countries = world.GetCountriesByContinentId(continentId);
      if (countries.Any())
        return Ok(countries);

      return NotFound($"Continent with id {continentId} is not available");
    }
  }
}
