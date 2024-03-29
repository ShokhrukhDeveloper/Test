using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
   ValueTask<Result> CreateResult(Result result);
   ValueTask<Result> UpdateResult(Result result);
   ValueTask<Result> RemoveResult(Result result);
   ValueTask<Result> GetResultById(int id);
   DbSet<Result> GetAllResults();

}