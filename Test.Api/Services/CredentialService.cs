using Test.Api.DTO.User;

namespace Test.Api.Services;

public class CredentialService : ICredentialService
{
    public ValueTask<UserDetails> CreateUser(NewUser user)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Session> Login(Credentials credentials)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDetails> GetUserDetailsByUserId(int id)
    {
        throw new NotImplementedException();
    }
}