using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
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

        public async Task<BaseAnswerVm<Account>> Authentificate(AuthentificateRequestDto request)
        {
            try
            {
                var account = await _dbContext.Accounts
                .Include(c => c.Employee)
                .Include(c => c.Employee.Departament)
                .Include(c => c.Employee.Post)
                .Include(c => c.Role)
                .FirstOrDefaultAsync(c => c.Username == request.Username && c.Password == request.Password);

                if (account == null)
                {
                    var response = new BaseAnswerVm<Account>()
                    {
                        Success = false,
                        Message = "Неправильный логин или пароль",
                        Content = null
                    };
                    return response;
                }

                var succResponse = new BaseAnswerVm<Account>()
                {
                    Success = true,
                    Message = "Успешная аутентификация",
                    Content = account
                };
                return succResponse;
            }
            catch(Exception ex)
            {
                var response = new BaseAnswerVm<Account>()
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
