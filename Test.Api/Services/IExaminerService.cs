using Test.Api.DTO;

namespace Test.Api.Services;

public interface IExaminerService
{
    ValueTask<DTO.Test.Test> StartTest(int userId,int testId,int numberOfTest);
    ValueTask<CheckedResult> CheckTest(CheckTestDTO checkTestDto);
}