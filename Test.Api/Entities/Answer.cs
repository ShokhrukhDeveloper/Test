namespace Test.Api.Entities;

public class Answer
{
    public int Id { get; set; }
    public int ResultId { get; set; }
    public virtual Result? Result { get; set; }
    public int  TestId { get; set; }
    public virtual Test? Test { get; set; }
    public int QuestionId { get; set; }
    public virtual Question? Question { get; set; }
    public int SelectedOpionId { get; set; }
    public virtual Option?  SelectedOpion { get; set; }
    public int CorrectOpionId { get; set; }
    public virtual Option?  CorrectOpion { get; set; }
    public bool Correct { get; set; } = false;
}