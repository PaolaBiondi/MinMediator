using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using minMediator.domain;

namespace minMediator.api.Controllers;

[ApiController]
[Route("[controller]")]
public class MinMediatorController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<MinMediatorController> _logger;
    private readonly IMediator _mediator;

    public MinMediatorController(ILogger<MinMediatorController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("Ping")]
    public async Task<IActionResult> Ping()
    {
        _logger.LogInformation("Start {method}", nameof(Ping));
        var response =  await _mediator.Send<PingRequest, Result<string>>(new PingRequest { Message = "Ping" });
        
        if (response.Errors.Any())
        {
            return BadRequest(response.Errors.First().Message);
        }

        _logger.LogInformation("End {method}", nameof(Ping));

        return Ok(response.Value);
    }

    [HttpGet("ShortTimeout")]
    public async Task<IActionResult> ShortTimeout(CancellationToken cancellationToken= default)
    {
        _logger.LogInformation("Start {methodnow} {now}", nameof(ShortTimeout), DateTime.Now.ToLongDateString());
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromMilliseconds(5));

        await Task.Delay(2000, cts.Token);

        _logger.LogInformation("End {method} {now}", nameof(ShortTimeout), DateTime.Now.ToLongDateString());
        return Ok();
    }
}
