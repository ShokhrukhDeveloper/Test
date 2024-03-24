namespace Test.Api.DTO;

public class CheckTestDTO
{
    public int TestId { get; set; }
    public List<AnswerDTO> Answers { get; set; }
}