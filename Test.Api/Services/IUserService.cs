using Test.Api.DTO;
using Test.Api.DTO.Credential;
using Test.Api.DTO.User;

namespace Test.Api.Services;

public interface IUserService
{
    ValueTask<ResultService<UserDetails>> CreateUser(NewUser user);
    ValueTask<ResultService<UserDetails>> UpdateUser(UpdateUser user);
    ValueTask<ResultService<Session>> LoginUser(LoginDTO login);
    ValueTask<ResultService<UserDetails>> GetUserById(int id);
    ValueTask<ResultService<string>> ChangePasswordByUserId(int userId,string oldPassword,string newPassword);
}