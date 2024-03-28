using Test.Api.Brokers;
using Test.Api.DTO;
using Test.Api.Entities;

namespace Test.Api.Services;

public class ExaminerService : IExaminerService
{
    private readonly IStorageBroker storageBroker;

    public ExaminerService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }
    public ValueTask<DTO.Test.Test> StartTest(int userId, int testId, int? numberOfTest=null)
    {
        throw new NotImplementedException();
    }

    public ValueTask<CheckedResultDTO> CheckTest(CheckTestDTO checkTestDto)
    {
        throw new NotImplementedException();
    }
}