using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using API.Extensions;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);  //Uses the ApplicationServiceExtensions in the extensions folder and this is an extension method
builder.Services.AddIdentityServices(builder.Configuration);     //Uses the IdentityServiceExtensions in the extensions folder and this is an extension method


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:4200", "https://localhost:4200"));   //the two URL's will be allowed to get data from the API

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
