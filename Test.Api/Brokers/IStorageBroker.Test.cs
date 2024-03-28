namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
    ValueTask<Entities.Test> InsertTestAsync(Entities.Test test);
    ValueTask<Entities.Test> RemoveTestAsync(Entities.Test test);
    ValueTask<Entities.Test> UpdateTestAsync(Entities.Test test);
    ValueTask<Entities.Test> GetByIdTestAsync(int id);
    IQueryable<Entities.Test> GetAllTest();
    

} 