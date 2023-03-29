using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndLinq
{
  internal static class ExtensionMethods
  {
    public static void Print<T>(this IEnumerable<T> list, string title = "")
    {
      Console.WriteLine($"************************ {title} *******************");
      foreach (var item in list)
      {
        Console.WriteLine(item);
      }

      Console.WriteLine("******************************************************");
      Console.WriteLine(); 
    }
  }
}
