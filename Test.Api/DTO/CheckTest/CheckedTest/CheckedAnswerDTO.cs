using Test.Api.DTO.Test;

namespace Test.Api.DTO.CheckTest;

public class CheckedAnswerDTO
{
    public int TestId { get; set; }
    public Result Result { get; set; }
    public List<QuestionResult> QuestionResults { get; set; }
}