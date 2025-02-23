using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Welcome to My API!" });
    }
}
