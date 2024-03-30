using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
    ValueTask<User> CreateUser(User result);
    ValueTask<User> UpdateUser(User result);
    ValueTask<User> RemoveUser(User result);
    ValueTask<User> GetUserById(int id);
   
    DbSet<User> GetAllUser();
}