using Microsoft.AspNetCore.Mvc;
using Test.Api.DTO;
using Test.Api.DTO.Credential;
using Test.Api.DTO.User;
using Test.Api.Services;

namespace Test.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService userService;
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpPost]
    public async  Task<ActionResult<ResultService<UserDetails>>> Create([FromBody]NewUser user)
    {
        var result = await this.userService.CreateUser(user);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpGet]
    public async  Task<ActionResult<ResultService<UserDetails>>> Get()
    {
        var result = await this.userService.GetUserById(1);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPost("Login")]
    public async  Task<ActionResult<ResultService<UserDetails>>> Login([FromBody]LoginDTO login)
    {
        var result = await this.userService.LoginUser(login);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    
}