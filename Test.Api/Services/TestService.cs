using Test.Api.DTO;
using Test.Api.DTO.Test;

namespace Test.Api.Services;

public class TestService : ITestService
{
    public ValueTask<TestDetails> CreateTest(NewTestDTO test)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IList<TestDetails>> GetLastTestList(int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }
}