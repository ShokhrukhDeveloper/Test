using System.ComponentModel.DataAnnotations;

namespace Test.Api.DTO.User;

public class NewUser
{
    [Required(ErrorMessage = "To'liq ism kitirish talab qilinadi")]
    public string FullName { get; set; }
    [StringLength(13, ErrorMessage = "Telefon raqami aniq 13 ta belgidan iborat bo'lishi kerak")]
    public string Phone { get; set; }
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Parol minimal 4 beligidan iborat bo'lishi zarur")]
    public string Password { get; set; }
}