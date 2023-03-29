using ConsoleApp2;

string t1 = "Hello world";
string t2 = "Hello";
t2 += " world";

Console.WriteLine(t1 == t2);
Console.WriteLine(t1.Equals(t2));

int x = 10;
x += x++ + ++x;

Console.WriteLine(x);

foreach (int c in new int[] {123,34,54,64})
{
  Console.WriteLine(c);
}

for (int i = 0;i < 10; i++) { Console.WriteLine(i); }

Class1.Sum(10, 20);
Class1.Sum(1.2, 3.4);
Class1.Sum(1, 2.3);


int result = Class1.SumOfList(new int[] { 123, 342, 235, 5 });
Console.WriteLine(result);

Console.WriteLine(Class1.SumOfList());
Console.WriteLine(Class1.SumOfList(12));
Console.WriteLine(Class1.SumOfList(1,2));
Console.WriteLine(Class1.SumOfList(1,2,3,4,5,6,7,8));

Console.WriteLine("info: {0}", result);

Console.ReadLine();


