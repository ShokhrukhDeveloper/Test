using Microsoft.AspNetCore.Mvc;
using Test.Api.DTO;
using Test.Api.DTO.Test;
using Test.Api.Services;

namespace Test.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;
    public TestController(ITestService testService)
    {
        _testService = testService;
    }
    [HttpGet]
    public IActionResult GetTestList()
    {
        return Ok();
    }
    [HttpPost]
    public async Task<ActionResult<TestDetails>> InsertTest(NewTestDTO testDto)
    {
        var test = await _testService.CreateTest(testDto);   
        return Ok(test);
    }
}