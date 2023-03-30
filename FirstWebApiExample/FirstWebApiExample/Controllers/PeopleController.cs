using FirstWebApiExample.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Text.Json.Serialization;

namespace FirstWebApiExample.Controllers
{
  [Route("[controller]")]
  public class PeopleController : ControllerBase
  {
    [HttpGet]
    public IEnumerable<Person> GetAll()
    {
      return People.Instance.Values;
    }

    [HttpGet("{id:int}")]
    public IActionResult GetPerson(int id)
    {
      //var person = People.Instance.FirstOrDefault(p => p.Id == id);
      //if (person is null)
      //  return NotFound($"Person with Id {id} not in the database");
      var dict = People.Instance;

      if (dict.TryGetValue(id, out var person))
        return Ok(person);

      return NotFound($"Person with Id {id} not in the database");
    }

    [HttpPost]
    public IActionResult AddPerson([FromBody] Person person)
    {
      People.Instance.TryAdd(person.Id, person);
      return Created($"people/{person.Id}", person);
    }
  }
}
