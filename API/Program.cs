using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);  //Uses the ApplicationServiceExtensions in the extensions folder and this is an extension method
builder.Services.AddIdentityServices(builder.Configuration);     //Uses the IdentityServiceExtensions in the extensions folder and this is an extension method


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();      //THis uses ExceptionMiddleware.cs for exception handling
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));   //the two URL's will be allowed to get data from the API

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
 
using var scope = app.Services.CreateScope();      //This section is used to seed data into the database
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();                //This adds any pending migrations to the database
    await Seed.SeedUsers(context);       //Uses SeedUsers from Seed.cs
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
