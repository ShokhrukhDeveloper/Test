namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
    ValueTask<Entities.Test> InsertTestAsync(Entities.Test test);
    IQueryable<Entities.Test> GetAllTest();

} 