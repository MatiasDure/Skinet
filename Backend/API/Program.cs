using API.Extensions;
using API.Middleware;
using API.Products.Requests.Create;
using API.Urls;
using Application;
using Application.Urls;
using FluentValidation;
using Infrastructure;
using Infrastructure.Data.Seed;
using Infrastructure.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApiCors();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
builder.Services.AddLocalImageStorage(Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath)!.FullName, "Storage", "Images", "Products"), "/images/products");
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUrlBuilder, UrlBuilder>();

var app = builder.Build();

// configure the HTTP request pipeline
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCors("Skinet");
app.MapControllers();
app.UseImageStorage();

if(app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();
}

app.Run();
