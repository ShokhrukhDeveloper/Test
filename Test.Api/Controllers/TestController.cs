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
    public async Task<ActionResult<IList<TestDetails>>> GetTestList()
    {
       var result= await _testService.GetLastTestList();
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<TestDetails>> InsertTest(NewTestDTO testDto)
    {
        var test = await _testService.CreateTest(testDto);   
        return Ok(test);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DTO.Test.Test>> GetTest(int id)
    {
        var result= await _testService.GetLastTestByIdAsync(id);
        return Ok(result);
    }
}