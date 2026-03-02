using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly IHostEnvironment _environment;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(
        IHostEnvironment environment,
        ILogger<ErrorHandlingMiddleware> logger, 
        RequestDelegate next)
    {
        _environment = environment;
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        } 
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError, 
                Title = ex.Message, 
                Detail = _environment.IsDevelopment() ? ex.StackTrace : "Internal server error.", 
                Instance = context.Request.Path
            };

            context.Response.StatusCode = problem.Status.Value; 
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
