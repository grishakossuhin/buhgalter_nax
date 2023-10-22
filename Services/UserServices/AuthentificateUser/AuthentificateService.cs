using BuhUchetApi.DataBase;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.UserServices.AuthentificateUser
{
    public class AuthentificateService
    {
        private readonly ApplicationContext _dbContext;

        public AuthentificateService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<FullEmployee>> Authentificate(AuthentificateRequestDto request)
        {
            try
            {
                var account = await _dbContext.Accounts.Include(u => u.Employee).FirstOrDefaultAsync(c => c.Username == request.Username && c.Password == request.Password);

                if (account == null)
                {
                    var response = new BaseAnswerVm<FullEmployee>()
                    {
                        Success = false,
                        Message = "Неправильный логин или пароль",
                        Content = null
                    };
                    return response;
                }

                var user = await GetFullEmployee.GetFullEmployee.Getemployee(account.Employee.Id);

                var succResponse = new BaseAnswerVm<FullEmployee>()
                {
                    Success = true,
                    Message = "Успешная аутентификация",
                    Content = user.Content
                };
                return succResponse;
            }
            catch(Exception ex)
            {
                var response = new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Ошибка получения данных. " + ex.Message,
                    Content = null
                };
                return response;
            }
            
        }
    }
}
