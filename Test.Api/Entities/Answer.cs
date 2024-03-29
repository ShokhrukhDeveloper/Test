namespace Test.Api.Entities;

public class Answer
{
    public int Id { get; set; }
    public int ResultId { get; set; }
    public virtual Result? Result { get; set; }
    public int QuestionId { get; set; }
    public virtual Question? Question { get; set; }
    public int OpionId { get; set; }
    public virtual Option?  Opion { get; set; }
    public bool Correct { get; set; } = false;
}