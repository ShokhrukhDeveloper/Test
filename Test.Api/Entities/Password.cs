namespace Test.Api.Entities;

public class Password
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PasswordHash { get; set; }
}