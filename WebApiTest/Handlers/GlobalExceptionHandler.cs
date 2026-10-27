using System;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApiTest.Handlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    // public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    // {
    //     throw new NotImplementedException();
    // }


    private readonly IServiceScopeFactory _scopeFactory;
    public GlobalExceptionHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<GlobalExceptionHandler>>();
        // var username = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimsKey.Username || c.Type == "name")?.Value;

        var exceptionMessage = $"Message : {exception.Message}\n InnerMessage: {exception.InnerException}";
        logger.LogError(exceptionMessage, exception.StackTrace, exception.Source, exception.TargetSite);

        return ValueTask.FromResult(false);
    }
}


