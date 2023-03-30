using FirstWebApiExample.Models;
using Microsoft.AspNetCore.Mvc;
//using System.Text.Json.Serialization;

namespace FirstWebApiExample.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class PeopleController : ControllerBase
  {
    private readonly People people;

    public PeopleController(People people)
    {
      this.people = people;
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(201)]
    [ProducesResponseType(404, Type = typeof(string))]
    public IEnumerable<Person> GetAll(/*[FromServices]People people*/)
    {
      return people.Values;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Person> GetPerson(int id)
    {
      //var person = People.Instance.FirstOrDefault(p => p.Id == id);
      //if (person is null)
      //  return NotFound($"Person with Id {id} not in the database");
      var dict = people;

      if (dict.TryGetValue(id, out var person))
        return Ok(person);

      return NotFound($"Person with Id {id} not in the database");
    }

    [HttpPost]
    public ActionResult<Person> AddPerson(/*[FromBody]*/ Person person)
    {
      //if (!ModelState.IsValid) return BadRequest();
      if (person.Id != 0)
        return BadRequest();

      int id = people.Keys.Max() + 1;

      person.Id = id;

      if (!people.TryAdd(id, person))
        return BadRequest();

      return Created($"/people/{id}", person);


    }
  }
}
