using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
  internal class Class1
  {
    public static double Sum(double x, double y) { return x + y; }
    public static int Sum(int x, int y) { return x + y; }

    public static int SumOfList(params int[] numbers)
    {
      int sum = 0;
      foreach (int x in numbers) sum += x;
      return sum;
    }
  }
}