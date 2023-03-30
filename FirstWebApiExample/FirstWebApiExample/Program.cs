using FirstWebApiExample.Models;

var builder = WebApplication.CreateBuilder(args);

// define dependecies here
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<People>();

var app = builder.Build();

// build pipeline


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string name) => $"Hello {name}");
app.Run();
