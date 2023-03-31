using FirstWebApiExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FirstWebApiExample.Controllers
{
  [Route("[controller]")]
  public class SampleController : IDisposable
  {
    private readonly IConfiguration configuration;
    private readonly ILogger<SampleController> logger;
    private readonly CompanyInfo companyInfo;

    public SampleController(IConfiguration configuration, IOptions<CompanyInfo> companyInfoOptions, ILogger<SampleController> logger)
    {
      this.configuration = configuration;
      this.logger = logger;
      companyInfo = companyInfoOptions.Value;
    }

    [HttpGet("CompanyInfo2")]
    public CompanyInfo GetCompanyInfo2()
    {
      logger.LogInformation("only for information");
      logger.LogError("an error occured");
      // use this
      logger.LogInformation("company was {companyname} with {count} number of employees", companyInfo.Name, companyInfo.NumberOfEmployees);

      // don't use this:
      logger.LogInformation($"company was {companyInfo.Name} with {companyInfo.NumberOfEmployees} ...");
      logger.LogInformation(string.Format("{0}", 123));

      return companyInfo;
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
