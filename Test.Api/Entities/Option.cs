namespace Test.Api.Entities;

public class Option
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Content { get; set; }
    public bool Correct { get; set; }
}