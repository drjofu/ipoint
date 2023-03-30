using System.ComponentModel.DataAnnotations;

namespace FirstWebApiExample.Models
{
  [AttributeUsage(AttributeTargets.Property,Inherited =true)]
  public class EvenNumberValidationAttribute : ValidationAttribute
  {
    public override bool IsValid(object? value)
    {
      if (value is null) return false;
      int number=(int)value;

      return number % 2 == 0;
    }
  }
}
