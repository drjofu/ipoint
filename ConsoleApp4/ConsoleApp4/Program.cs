namespace ConsoleApp4
{
  internal class Program
  {
    static void Main(string[] args)
    {
      DoSomething("C#");
      DoSomething(123);

      object obj = 456;
      int i = (int)obj;

      Console.WriteLine(obj.GetType().Name);
      Console.WriteLine(obj is int);

      obj = 1.23;
      i = (int)(double)obj;

      object oj1 = 1;
      object oj2 = 1;

      Console.WriteLine(oj1 == oj2);

      DoSomethingElse<string>("C#");
      DoSomethingElse("C#");
      DoSomethingElse(123);

      List<int> list = new List<int>();
      list.Add(12);
      //      list.Add("xxx");

      int z = list[0];

      Nullable<int> count = 123;
      count = null;

      int q;
      if (count.HasValue)
        q = count.Value;

      q = count.GetValueOrDefault(42);

      int? count2 = null;

      Company company= new Company();

      var result = company?.Employees[0]?.Address?.City;

      int? number = company?.Employees[0]?.Address?.HouseNumber;
      int number2 = company?.Employees[0]?.Address?.HouseNumber ?? 42;

      List<int> list2 = null;

      list2 ??= new List<int>();
      list2 ??= new List<int>();
      

      Console.WriteLine();

      Console.ReadLine();
    }

    static void DoSomething(object obj)
    {
      Console.WriteLine($"doing something with {obj}");
    }

    static void DoSomethingElse<T>(T something)
    {
      Console.WriteLine($"doing something with {something}");

    }
  }
}