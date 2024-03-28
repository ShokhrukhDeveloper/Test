namespace Test.Api.DTO.CheckTest;

public class Result
{
    public int Id { get; set; }
    public int Score { get; set; }
    public int CorrectAnswer { get; set; }
    public int InCorrectAnswer { get; set; }
    public DateTime CompletedAt { get; set; }
}