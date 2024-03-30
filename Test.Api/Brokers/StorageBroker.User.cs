using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial class StorageBroker
{
    public async ValueTask<User> CreateUser(User user)
    {
       var result= _dbContext.Users.Add(user);
       await  _dbContext.SaveChangesAsync();
       return result.Entity;
    } 

    public async ValueTask<User> UpdateUser(User user)
    {
        var result= _dbContext.Users.Update(user);
        await  _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<User> RemoveUser(User user)
    {
        var result= _dbContext.Users.Remove(user);
        await  _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<User> GetUserById(int id)
        => await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);


   

    public DbSet<User> GetAllUser()
        => _dbContext.Users;
}