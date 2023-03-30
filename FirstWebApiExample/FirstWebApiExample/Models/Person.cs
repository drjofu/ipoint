using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstWebApiExample.Models
{
  public class Person
  {
   
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [StringLength(10,MinimumLength =2)]
    public string LastName { get; set; }

    [Range(18,120)]
    [EvenNumberValidation]
    public int Age { get; set; }

    [JsonIgnore]
    public string Password { get; set; } = "top secret";
  }

  public class People: ConcurrentDictionary<int, Person>
  {
    //public static readonly People Instance = new People();

    public People()
    {
      this.TryAdd(1,new Person { Id = 1, FirstName = "Micky", LastName = "Mouse", Age = 50 });
      this.TryAdd(2,new Person { Id = 2, FirstName = "Donald", LastName = "Duck", Age = 47 });
      this.TryAdd(3,new Person { Id = 3, FirstName = "Daisy", LastName = "Duck", Age = 33 });
      this.TryAdd(4,new Person { Id = 4, FirstName = "Dagobert", LastName = "Duck", Age = 66 });
    }
  }
}
