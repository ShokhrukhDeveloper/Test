using Microsoft.EntityFrameworkCore;
using Test.Api.Brokers;
using Test.Api.Constants;
using Test.Api.DTO;
using Test.Api.DTO.Credential;
using Test.Api.DTO.User;
using Test.Api.Entities;
using Test.Api.Extensions;

namespace Test.Api.Services;

public class UserService : IUserService
{
    private readonly IStorageBroker storageBroker;
    private readonly IJWTService jwtService;
    public UserService(IJWTService jwtService,IStorageBroker storageBroker)
    {
        this.storageBroker = storageBroker;
        this.jwtService = jwtService;
    }
    public async ValueTask<ResultService<UserDetails>> CreateUser(NewUser user)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                return new(false)
                {
                    ErrorMessage = "To'liq  ismini kiritishda xatolik tekshirib qayta harakat qiling"
                };
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                return new(false)
                {
                    ErrorMessage = "Parolni kiritishda xatolik tekshirib qayta harakat qiling"
                };
            }
            if (string.IsNullOrWhiteSpace(user.Phone))
            {
                return new(false)
                {
                    ErrorMessage = "Tel nomerni kiritishda xatolik tekshirib qayta harakat qiling"
                };
            }
            
            var newUser = await storageBroker.CreateUser(new User()
            {
                FullName = user.FullName,
                Phone = user.Phone,
                Password = new Password()
                {
                    PasswordHash = user.Password.ToSha256()
                }
            });
            return new ResultService<UserDetails>(true)
            {
                Data = new UserDetails()
                {
                    Id = newUser.Id,
                    FullName = newUser.FullName,
                    Phone = newUser.Phone,
                    Score = newUser.Score
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public ValueTask<ResultService<UserDetails>> UpdateUser(UpdateUser user)
    {
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public async ValueTask<ResultService<Session>> LoginUser(LoginDTO login)
    {
        try
        {
            if (login.Phone.Length != 13)
            {
                return new ResultService<Session>(false)
                {
                    ErrorMessage = $"Ushbu {login.Phone} raqam noto'g'ri kiritilgan "
                };
            }
            var result = await storageBroker.GetUserPasswordByPhoneNumber(login.Phone);
            if (result is null)
            {
                return new ResultService<Session>(false)
                {
                    ErrorMessage = $"Ushbu {login.Phone} raqami topilmadi "
                };
            }

            if (result.PasswordHash!=login.Password.ToSha256())
            {
                return new ResultService<Session>(false)
                {
                    ErrorMessage = "Parol yoki tel nomer no'to'g'ri kiritlgan"
                };
            }

            return new ResultService<Session>(true)
            {
                Data = new Session()
                {
                    Token = jwtService.GenerateToken(new JwtConst(result.UserId,""))
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }

    public async ValueTask<ResultService<UserDetails>> GetUserById(int id)
    {
        try
        {
            var result = await storageBroker.GetUserById(id);
            if (result is null)
            {
                return new ResultService<UserDetails>(false)
                {
                    ErrorMessage = "Foydalanuvchi topilmadi"
                };
            }

            return new ResultService<UserDetails>(true)
            {
                Data = new UserDetails()
                {
                Id = result.Id,
                FullName = result.FullName,
                Phone = result.Phone,
                Score = result.Score
                }
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        throw new NotImplementedException();
    }

    public async ValueTask<ResultService<string>> ChangePasswordByUserId(int userId, string oldPassword, string newPassword)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(oldPassword)||oldPassword.Length<4)
            {
                return new ResultService<string>(false)
                {
                    ErrorMessage = $"Ushbu eski parol uzunligi kamida 4 belgidan iborat bo'lsin "
                };
            }
            if (string.IsNullOrWhiteSpace(newPassword)||newPassword.Length<4)
            {
                return new ResultService<string>(false)
                {
                    ErrorMessage = $"Ushbu yang parol uzunligi kamida 4 belgidan iborat bo'lsin "
                };
            }
            var user = await storageBroker.GetAllUser().Include(e => e.Password).FirstOrDefaultAsync(w => w.Id == userId);
            if (user.Password.PasswordHash!=oldPassword.ToSha256())
            {
                return new ResultService<string>(false)
                {
                    ErrorMessage = "Eski parol noto'gri kiritilgan"
                };
            }

            user.Password.PasswordHash = newPassword.ToSha256();
            storageBroker.UpdateUser(user);
            return new ResultService<string>(true)
            {
                Data = "Parol muvoffaqiyatli o'zgartirildi👌!"
            };
        }
        catch(Exception exception)
        {
            throw new Exception("Serverda xatolik yuz berdi");
        }
        
    }
}