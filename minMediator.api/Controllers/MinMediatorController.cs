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
        var response =  await _mediator.Send<PingRequest, string>(new PingRequest { Message = "Ping" });
        return Ok(response);
    }
}
