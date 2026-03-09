using API.Middleware;
using API.Products.Requests.Create;
using Application;
using FluentValidation;
using Infrastructure;
using Infrastructure.Data.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
   options.AddPolicy("Skinet", p =>
   {
       p.AllowAnyHeader();
       p.AllowAnyMethod();
       p.AllowAnyOrigin(); // TODO: Update to specific frontned origin
   });
});
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();

var app = builder.Build();

// configure the HTTP request pipeline
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("Skinet");
app.MapControllers();

if(app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();
}

app.Run();
