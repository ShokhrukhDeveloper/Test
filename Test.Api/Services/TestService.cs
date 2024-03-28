using Microsoft.EntityFrameworkCore;
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

    public async ValueTask<IList<TestDetails>> GetLastTestList(int page = 1, int limit = 10)
    {
        try
        {
            var result = await storageBroker.GetAllTest().OrderByDescending(e => e.Id).Take(limit).ToListAsync();
            return result.Select(ToTestDetails).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async ValueTask<DTO.Test.Test> GetLastTestByIdAsync(int id)
    {
        try
        {
            var result = await storageBroker.GetByIdTestAsync(id);
            if (result is null)
            {
                return new DTO.Test.Test();
            }

            return ToDTO(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}