using Test.Api.Brokers;
using Test.Api.Data;
using Test.Api.DTO;
using Test.Api.DTO.Test;

namespace Test.Api.Services;

public partial class TestService : ITestService
{
    private readonly IStorageBroker storageBroker;

    public TestService(IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
    }
    public async ValueTask<TestDetails> CreateTest(NewTestDTO test)
    {
       var result= await storageBroker.InsertTestAsync(ToEntity(test));
       return new TestDetails
       {
           TestId = result.Id,
           numberOfQuestion = result.Questions.Count(),
           Name = result.Name,
           Description=result.Description
       };
    }

    public ValueTask<IList<TestDetails>> GetLastTestList(int page = 1, int limit = 10)
    {
        throw new NotImplementedException();
    }
}