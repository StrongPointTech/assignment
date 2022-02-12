using Microsoft.AspNetCore.Http;

namespace KineticEnergy.Server;


public class CancelationHandling : IMiddleware
{
    private readonly ILogger _logger;

    public CancelationHandling(ILogger<CancelationHandling> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (TaskCanceledException e)
        {
            if(_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation("Task cancelled: {0}", e.Task?.ToString());
        }
        catch (OperationCanceledException)
        {
            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation($"Operation cancelled");
        }

    }
}



