using Microsoft.AspNetCore.Mvc;
using Test.Api.Data;
using Test.Api.DTO;
using Test.Api.DTO.User;
using Test.Api.Entities;
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
    
}