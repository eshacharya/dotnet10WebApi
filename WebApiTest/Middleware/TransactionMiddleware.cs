using System;

namespace WebApiTest.Middleware;

public class TransactionMiddleware(RequestDelegate next, ILogger<TransactionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context, ShopDbContext db)
    {
        // Reads don't need a transaction
        if (HttpMethods.IsGet(context.Request.Method) ||
            HttpMethods.IsHead(context.Request.Method) ||
            HttpMethods.IsOptions(context.Request.Method))
        {
            await next(context);
            return;
        }

        await using var transaction = await db.Database.BeginTransactionAsync(context.RequestAborted);

        try
        {
            await next(context);

            if (context.Response.StatusCode >= 400)
            {
                await transaction.RollbackAsync(CancellationToken.None);
                logger.LogWarning("Rolled back transaction, status {StatusCode}", context.Response.StatusCode);
                return;
            }

            await transaction.CommitAsync(context.RequestAborted);
        }
        catch
        {
            await transaction.RollbackAsync(CancellationToken.None);
            throw; // let the exception handler / logger deal with it
        }
    }
}
public static class UoWMiddlewareExtension
{
    public static void UseUoWMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<TransactionMiddleware>();
    }
}