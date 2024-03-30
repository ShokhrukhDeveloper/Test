using Microsoft.EntityFrameworkCore;
using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial class StorageBroker
{
    public async ValueTask<Password> GetUserPasswordByUserId(int Id)
   =>(await _dbContext.Users.
        Include(e=>e.Password).
        FirstOrDefaultAsync(p=>p.Id==Id))?.
        Password;
  
    public async ValueTask<Password> GetUserPasswordByPhoneNumber(string phone)
        => (await _dbContext.Users.
                Include(e=>e.Password).
                FirstOrDefaultAsync(p=>p.Phone==phone))?.
            Password;
    
    public async ValueTask<Password> UpdateUserPassword(Password password)
    {
        var result = _dbContext.Passwords.Update(password);
        await SaveChangesAsync();
        return result.Entity;
    }

    public async ValueTask<Password> CreatePassword(Password password)
    {
        var result = _dbContext.Passwords.Add(password);
        await SaveChangesAsync();
        return result.Entity;
    }
}