namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
    public ValueTask<int> SaveChangesAsync();
}