using Test.Api.DTO.User;

namespace Test.Api.Services;

public interface ICredentialService
{
   ValueTask<UserDetails> CreateUser(NewUser user);
   ValueTask<Session> Login(Credentials credentials);
   ValueTask<UserDetails> GetUserDetailsByUserId(int id);
   
}