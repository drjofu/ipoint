using System;

namespace ConsoleApp3
{
  internal class Person : IDisposable
  {
    public static readonly Person TheInstance = new Person();
    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public int NameLength
    {
      get { return name.Length; }
    }

    public int LengthOfName => name.Length;

    int abc;
    public int MyProperty
    {
      get => 123;
      set => abc = value;
    }

    public string Address { get; private set; }

    public string City { get; } = GetCity();

    private static string GetCity() { return "Cologne"; }

    private Person() : this("noname")
    {

    }

    
    private Person(string name, string address = "nothing")
    {
      this.City = "Reutlingen";
      this.Address = address;
      this.name = name;
    }

    public static Person Create(string name) { return new Person(name); }

    public void Dispose()
    {
      // dispose external resources
    }

    static Person()
    {

    }
  }
}
