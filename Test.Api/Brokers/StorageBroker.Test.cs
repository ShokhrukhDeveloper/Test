using Microsoft.EntityFrameworkCore;

namespace Test.Api.Brokers;

public partial class StorageBroker
{
    public async  ValueTask<Entities.Test> InsertTestAsync(Entities.Test test)
    {
        
       var result= _dbContext.Tests.Add(test);
        await  _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Entities.Test> RemoveTestAsync(Entities.Test test)
    {
        var result= _dbContext.Tests.Remove(test);
        await  _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Entities.Test> UpdateTestAsync(Entities.Test test)
    {
        var result= _dbContext.Tests.Update(test);
        await  _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Entities.Test> GetByIdTestAsync(int id)
        => await _dbContext.Tests.FirstOrDefaultAsync(t => t.Id == id);
     

    public IQueryable<Entities.Test> GetAllTest()
        => _dbContext.Tests;
}