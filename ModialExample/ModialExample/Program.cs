using ModialExample.Middleware;
using ModialExample.Models;
using ModialExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<World>();

builder.Services.AddCors(options =>
{
  options.AddPolicy("Cors", pb =>
  {
    pb.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(_=>true);
  });
});

builder.Services.AddSingleton<TimingService>();
builder.Services.AddHostedService<OurBackgroundService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/error-development");
}
else
{
  app.UseExceptionHandler("/error");
}

app.Use(async (ctx, next) =>
{
  app.Logger.LogInformation("before");
  await next();
  app.Logger.LogInformation("after");
});

//app.UseMiddleware<TimingMiddleware>();
app.UseTiming();

app.UseCors("Cors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
