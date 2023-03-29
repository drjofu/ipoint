using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
  
  internal interface ITaxObject
  {
    void PayTax();
    int TaxNumber { get; }
  }

  internal class Car : ITaxObject
  {
    public int TaxNumber => throw new NotImplementedException();

    public void PayTax()
    {
      throw new NotImplementedException();
    }
  }

  internal class Dog : ITaxObject
  {
    int ITaxObject.TaxNumber => throw new NotImplementedException();

    void ITaxObject.PayTax()
    {
      Console.WriteLine(((ITaxObject) this).TaxNumber);
    }
  }
}
