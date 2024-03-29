using Test.Api.DTO.Credential;
using Test.Api.DTO.User;
using Test.Api.Entities;

namespace Test.Api.Services;

public interface IUserService
{
   ValueTask<UserDetails> CreateUser(NewUser user);
   ValueTask<UserDetails> GetUserDetailsById(int id);
   ValueTask<UserDetails> UpdateUser(User user);
   ValueTask<UserDetails> DeleteUser(User user);
   ValueTask<Session> LoginUser(LoginDTO login);
   ValueTask<bool> UpdateUserPassword( login);
   
}