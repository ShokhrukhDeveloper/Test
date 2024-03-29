using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial class StorageBroker
{
    public async ValueTask<Result> CreateResult(Result result)
    {
        var resultAdded = _dbContext.Results.Add(result);
        await  _dbContext.SaveChangesAsync();
        return resultAdded.Entity;
    }

    public async ValueTask<Result> UpdateResult(Result result)
    {
       var resultUpdated= _dbContext.Results.Update(result);
       await  _dbContext.SaveChangesAsync();
       return resultUpdated.Entity;
    }

    public async ValueTask<Result> RemoveResult(Result result)
    {
        var resultRemoved = _dbContext.Results.Remove(result);
        await  _dbContext.SaveChangesAsync();
        return resultRemoved.Entity;
    }

    public async ValueTask<Result> GetResultById(int id)
        => await _dbContext.Results.FirstOrDefaultAsync(e=>e.Id==id);
     

    public DbSet<Result> GetAllResults()
        => _dbContext.Results;
}