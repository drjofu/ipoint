using System.Collections.Concurrent;

namespace FirstWebApiExample.Models
{
  public class Person
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

  }

  public class People: ConcurrentDictionary<int, Person>
  {
    public static readonly People Instance = new People();

    private People()
    {
      this.TryAdd(1,new Person { Id = 1, FirstName = "Micky", LastName = "Mouse", Age = 50 });
      this.TryAdd(2,new Person { Id = 2, FirstName = "Donald", LastName = "Duck", Age = 47 });
      this.TryAdd(3,new Person { Id = 3, FirstName = "Daisy", LastName = "Duck", Age = 33 });
      this.TryAdd(4,new Person { Id = 4, FirstName = "Dagobert", LastName = "Duck", Age = 66 });
    }
  }
}
