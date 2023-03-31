
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
//builder.Services.AddApiVersioning(config =>
//{
//  config.DefaultApiVersion = new ApiVersion(1, 0);
//  config.AssumeDefaultVersionWhenUnspecified=true;
//  config.ReportApiVersions= true;
//  //config.ApiVersionReader = new HeaderApiVersionReader("api-version");
//}).AddMvc();

builder.Services.AddApiVersioning(options =>
{
  options.ReportApiVersions= true;
  options.DefaultApiVersion = new(1, 1);
  options.AssumeDefaultVersionWhenUnspecified=true;
  options.ApiVersionReader = new HeaderApiVersionReader("api-version");
}).AddMvc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //app.UseSwagger();
  //app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();
