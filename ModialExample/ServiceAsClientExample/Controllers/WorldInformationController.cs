using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ServiceAsClientExample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class WorldInformationController : ControllerBase
  {
    private HttpClient httpClient;
    private IConfiguration configuration;

    public WorldInformationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
      httpClient= httpClientFactory.CreateClient();
      this.configuration = configuration;
    }

    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
      string url = $"{configuration["ServiceUrl"]}continent";
      var continents = await httpClient.GetFromJsonAsync<IEnumerable<Continent>>(url);
      string information=string.Join(", ",continents.Select(continent => continent.Name));
      return Ok(information);
    }
  }
}
