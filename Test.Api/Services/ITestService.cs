using Test.Api.DTO;
using Test.Api.DTO.Test;

namespace Test.Api.Services;

public interface ITestService
{
    ValueTask<TestDetails> CreateTest(NewTestDTO test);
    ValueTask<IList<TestDetails>> GetLastTestList(int page=1,int limit=10);
    ValueTask<DTO.Test.Test> GetLastTestByIdAsync(int id);

}