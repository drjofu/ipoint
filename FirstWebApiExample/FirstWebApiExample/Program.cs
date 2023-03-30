var builder = WebApplication.CreateBuilder(args);

// define dependecies here
builder.Services.AddControllers();

var app = builder.Build();

// build pipeline

app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string name) => $"Hello {name}");
app.Run();
