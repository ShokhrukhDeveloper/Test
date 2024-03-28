using Test.Api.DTO;

namespace Test.Api.Services;

public class ExaminerService : IExaminerService
{
    public ValueTask<DTO.Test.Test> StartTest(int userId, int testId, int numberOfTest)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CheckedResult> CheckTest(CheckTestDTO checkTestDto)
    {
        throw new NotImplementedException();
    }
}