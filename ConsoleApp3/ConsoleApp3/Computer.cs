using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
  internal class Computer
  {
    public int Memory { get; init; }
    public string OperatingSystem { get; set; }

  }

  public record Keyboard(int NumberOfKeys, string Language)
  {
    public double Price { get; set; } = 123;
  }
}
