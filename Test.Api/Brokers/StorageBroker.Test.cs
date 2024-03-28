namespace Test.Api.Brokers;

public partial class StorageBroker
{
    public ValueTask<Entities.Test> InsertTestAsync(Entities.Test test)
    {
        _dbContext.Tests.Add(test);
        throw new NotImplementedException();
    }

    public IQueryable<Entities.Test> GetAllTest()
    {
        throw new NotImplementedException();
    }
}