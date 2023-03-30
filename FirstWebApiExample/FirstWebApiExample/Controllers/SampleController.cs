using FirstWebApiExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApiExample.Controllers
{
  [Route("[controller]")]
  public class SampleController : IDisposable
  {
    private readonly IConfiguration configuration;

    public SampleController(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    [HttpGet("CompanyName")]
    public string GetCompanyName()
    {
      return configuration["Company:Name"];
    }

    [HttpGet("NumberOfEmployees")]
    public int GetCount()
    {
      return configuration.GetValue<int>("Company:NumberOfEmployees");
    }

    [HttpGet("CompanyInfo")]
    public CompanyInfo GetCompanyInfo()
    {
      var companyInfo= new CompanyInfo();
      configuration.GetSection("Company").Bind(companyInfo);

      return companyInfo;
    }

    [HttpGet]
    public string Get()
    {
      return "Good morning!";
    }

    [HttpGet("hello")]
    public string SayHello(string name)
    {
      return $"Hello {name}";
    }

    [HttpGet("add")]
    public int Add(int a, int b)
    {
      return a + b;
    }

    public void Dispose()
    {
      // clean up if needed
    }

  }
}
