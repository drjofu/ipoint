using FirstWebApiExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FirstWebApiExample.Data;
using FirstWebApiExample.Controllers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FirstWebApiExampleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FirstWebApiExampleContext") ?? throw new InvalidOperationException("Connection string 'FirstWebApiExampleContext' not found.")));

// define dependecies here
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<People>();

builder.Services.AddOptions<CompanyInfo>()
  .Bind(builder.Configuration.GetSection("Company"))
  .ValidateDataAnnotations()
  .ValidateOnStart();

var app = builder.Build();

// build pipeline


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string name) => $"Hello {name}");

app.MapPersonEndpoints();
app.Run();
