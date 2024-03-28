namespace Test.Api.DTO.CheckTest;

public class Question
{
    public int Id { get; set; }
    public virtual Option?  SelectedOpion { get; set; }
    public int CorrectOpionId { get; set; }
    public virtual Option?  CorrectOpion { get; set; }
    public bool Correct { get; set; } = false;
}