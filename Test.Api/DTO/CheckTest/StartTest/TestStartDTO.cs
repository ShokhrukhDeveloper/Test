
using Test.Api.DTO.Test;

namespace Test.Api.DTO.CheckTest;

public class TestStartDTO
{
    public int  CheckerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int TimeAllowed { get; set; }
    public List<Question> Questions { get; set; }
}