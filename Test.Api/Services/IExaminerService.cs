using Test.Api.DTO;
using Test.Api.DTO.CheckTest;

namespace Test.Api.Services;

public interface IExaminerService
{
    ValueTask<DTO.CheckTest.TestStartDTO> StartTest(int userId,int testId,int? numberOfTest=null);
    ValueTask<Result<CheckedAnswerDTO>> CheckTest(CheckTestDTO checkTestDto);
}