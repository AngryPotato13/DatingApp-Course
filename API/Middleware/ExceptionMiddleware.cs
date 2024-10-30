using System;
using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);      //moves onto next request deligate if theres no errors
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = env.IsDevelopment()   //checks to see if were in developer mode
                ? new ApiExceptions(context.Response.StatusCode, ex.Message, ex.StackTrace)        //Displays this if we are in developer mode
                : new ApiExceptions(context.Response.StatusCode, ex.Message, "Internal server error");   //Displays this if we are in another mode
            
            var options = new JsonSerializerOptions    //Because its returned as a json response this creates options for it
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
