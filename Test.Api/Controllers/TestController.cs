using Microsoft.AspNetCore.Mvc;
using Test.Api.DTO;

namespace Test.Api.Controllers;
[ApiController]
[Route("{controller}")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetTestList()
    {
        return Ok();
    }
    [HttpPost]
    public IActionResult InsertTest(NewTestDTO testDto)
    {
        
        return Ok();
    }
}