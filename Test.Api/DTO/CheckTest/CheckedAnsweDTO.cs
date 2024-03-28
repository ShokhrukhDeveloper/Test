using Test.Api.DTO.Test;

namespace Test.Api.DTO.CheckTest;

public class CheckedAnswerDTO
{
    public int QuestionId { get; set; }
    public Result Result { get; set; }
    public List<Question> Questions { get; set; }
}