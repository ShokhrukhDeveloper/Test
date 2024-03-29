using System.ComponentModel.DataAnnotations;

namespace Test.Api.DTO.Credential;
public class LoginDTO
{
    
    public string Phone { get; set; }
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Parol 4 dan 50 gacha belgidan iborat bo'lishi kerak")]
    public string Password { get; set; }
}