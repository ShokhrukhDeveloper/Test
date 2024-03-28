namespace Test.Api.DTO.CheckTest;

public class QuestionResult
{
    public int Id { get; set; }
    public OptionResult?  SelectedOpion { get; set; }
    public int CorrectOpionId { get; set; }
    public OptionResult?  CorrectOpion { get; set; }
    public bool Correct { get; set; } = false;
}