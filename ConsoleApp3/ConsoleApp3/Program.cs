using System;
using System.Collections.Generic;
using io = System.IO;
using static System.Math;
using System.Reflection;

namespace ConsoleApp3;

internal class Program
{
  static void Main(string[] args)
  {
    DoSomething("learn c#", 15);

    DoSomething();
    DoSomething("learn C#");
    DoSomething(howLong: 30);
    DoSomething(howLong: 45, what: "forget Java");
    int a = 10;
    int b = 20;
    Exchange(ref a, ref b);

    Console.WriteLine("a: {0}, b: {1}", a, b);

    int c;
    Initialize(out c);

    Console.WriteLine(c);

    string t = "abc";
    //int d;
    if (int.TryParse(t, out int d))
      Console.WriteLine("d: {0}", d);
    else
      Console.WriteLine("not a number");

    Console.WriteLine("d: {0}", d);

    var x = GetNumbers();
    (int xxx, int yyy, string ttt) = GetNumbers();
    Console.WriteLine(xxx);

    List<int> list;
    Abs(123);

    Person p = Person.Create("Daisy");
    Console.WriteLine(p.Name);
    Console.WriteLine(p.NameLength);

    Type type = p.GetType();
    Console.WriteLine(type.GetProperty("Address").Name);
    foreach (var fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
    {
      Console.WriteLine(fi.Name);
    }

    Console.WriteLine(p.City);

    var computer = new Computer { Memory = 123, OperatingSystem = "Windows" };

    //computer.Memory = 456;

    Keyboard keyboard = new Keyboard(100, "DE") { Price = 55 };
    Console.WriteLine(keyboard.Language);
    Console.WriteLine(keyboard.NumberOfKeys);
    Console.WriteLine(keyboard);

    p.Dispose();
    p.Dispose();
    p.Dispose();

    var p2 = Person.Create("Micky");
    try
    {
      Console.WriteLine(p2.Name);

    }
    finally
    {
      p2.Dispose();
    }

    using (var p3 = Person.Create("Mouse"))
    {
      Console.WriteLine(p3.Name);
    }

    using var p4 = Person.Create("Mouse");
    Console.WriteLine(p4.Name);

    Console.ReadLine();
  }

  private static (int a, int b, string t) GetNumbers() { return (10, 20, "aha"); }

  private static void Initialize(out int c)
  {
    //Console.WriteLine(c);
    c = 123;
  }

  static void Exchange(ref int x, ref int y)
  {
    int h = x;
    x = y;
    y = h;
  }
  static void DoSomething(string what = "nothing", int howLong = 100)
  {
    Console.WriteLine("doing {0} for {1} minutes", what, howLong);
  }
}