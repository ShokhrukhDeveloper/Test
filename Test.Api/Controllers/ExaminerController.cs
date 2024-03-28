using Microsoft.AspNetCore.Mvc;
using Test.Api.DTO;
using Test.Api.DTO.CheckTest;
using Test.Api.DTO.CheckTest;
using Test.Api.Services;

namespace Test.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class ExamController : ControllerBase
{
    private readonly IExaminerService examinerService;

    public ExamController(IExaminerService examinerService)
    {
        this.examinerService = examinerService;
    }
    [HttpGet("Test/{testId}")]
    public async Task<ActionResult> StartTest(int testId)
    {
        var result = await examinerService.StartTest(1,testId);
        return Ok(result);
    } 
    [HttpGet("Results")]
    public async Task<ActionResult> StartTest()
    {
        
        return await  Task.FromResult(Ok(new TestStartDTO() ));
    }
    
    [HttpPost("Checker/{checkerId}")]
    public async Task<ActionResult> CheckerTest(int checkerId,[FromBody]CheckTestDTO testDto)
    {
        var result = await examinerService.CheckTest(testDto);
        return Ok(result);
    }
    
}