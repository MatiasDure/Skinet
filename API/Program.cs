var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// configure the HTTP request pipeline
app.MapControllers();

app.Run();
