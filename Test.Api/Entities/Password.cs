namespace Test.Api.Entities;

public class Password
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string PasswordHash { get; set; }
}