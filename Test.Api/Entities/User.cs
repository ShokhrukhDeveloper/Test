namespace Test.Api.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public double Score { get; set; }
    public virtual Password Password { get; set; }
    public virtual ICollection<Result>? Results { get; set; }
}