namespace Test.Api.DTO;

public class NewTestDTO
{
    public string TestName { get; set; }
    public string Content { get; set; }
    public List<NewQuestionDTO> Questions { get; set; }
}