using Test.Api.DTO.Credential;
using Test.Api.DTO.User;
using Test.Api.Entities;

namespace Test.Api.Services;

public class UserService : IUserService
{
    public ValueTask<UserDetails> CreateUser(NewUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDetails> GetUserDetailsById(int id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDetails> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDetails> DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Session> LoginUser(LoginDTO login)
    {
        throw new NotImplementedException();
    }
}