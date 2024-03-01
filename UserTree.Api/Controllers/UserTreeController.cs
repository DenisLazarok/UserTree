using Microsoft.AspNetCore.Mvc;

namespace UserTree.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserTreeController : ControllerBase
{
    private readonly ILogger<UserTreeController> _logger;

    public UserTreeController(ILogger<UserTreeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public void Get()
    {
        
    }
}