using Test.Api.Entities;

namespace Test.Api.Brokers;

public partial interface IStorageBroker
{
     ValueTask<Password> GetUserPasswordByPhoneNumber(string phone);
     ValueTask<Password> GetUserPasswordByUserId(int Id);
     ValueTask<Password> UpdateUserPassword(Password password);
     ValueTask<Password> CreatePassword(Password password);
}