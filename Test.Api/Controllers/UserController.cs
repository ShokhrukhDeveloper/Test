using Microsoft.AspNetCore.Mvc;
using Test.Api.Data;
using Test.Api.Entities;

namespace Test.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ApplicationDbContext _context;
    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetX()
    {
      var res=  _context.Users.Add(new User()
        {
            FullName = "jasfgjasldfghlasdg",
            Phone = "+998997531097",
            Score = 0.0f
        });
      _context.SaveChanges();
        return Ok(res.Entity);
    }
}