using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ExaminerController : ControllerBase
{
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}