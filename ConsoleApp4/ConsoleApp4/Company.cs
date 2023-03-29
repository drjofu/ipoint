using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
  internal class Company
  {
   public  List<Employee> Employees { get; set; }
  }

  class Employee
  {
    public Address Address { get; set; }
  }

  class Address
  {
    public string City { get; set; }
    public int HouseNumber { get; set; }
  }
}
