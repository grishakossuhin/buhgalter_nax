using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using System;
using System.Threading.Tasks;
using static BuhUchetApi.Models.Enums;

namespace BuhUchetApi.Services.RegisterUser
{
    public class RegisterUserService
    {
        private readonly ApplicationContext _dbContext;
        public RegisterUserService(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task<BaseAnswerVm<Account>> Register(RegisterRequestDto request)
        {
            var account = new Account()
            {
                Username = request.Username,
                Password = request.Password,
                Employee = new Employee()
                {
                    Firstname = request.Firstname,
                    Secondname = request.Secondname,
                    Thirdname = request.Thirdname,
                }
            };




            try
            {
                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();
                var response = new BaseAnswerVm<Account>()
                {
                    Success = true,
                    Message = "Успешная регистрация пользователя",
                    Content = account
                };
                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseAnswerVm<Account>()
                {
                    Success = false,
                    Message = "Ошибка сохранения в базу. " + ex.Message,
                    Content = account
                };
                return response;
            }
        }
    }
}
