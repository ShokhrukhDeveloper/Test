using Test.Api.Data;

namespace Test.Api.Brokers;

public partial class StorageBroker : IStorageBroker
{
    private readonly ApplicationDbContext _dbContext;

    public StorageBroker(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<int> SaveChangesAsync()
        =>await _dbContext.SaveChangesAsync();
}