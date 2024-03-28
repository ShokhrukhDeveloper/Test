namespace Test.Api.Entities;

public class Result
{
    public int Id { get; set; }
    public int TestId { get; set; }
    public virtual Test? Test { get; set; }
    public int UserId { get; set; }
    public virtual  User User { get; set; }
    public  int Score { get; set; }
    public virtual ICollection<Answer>? Answers { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}