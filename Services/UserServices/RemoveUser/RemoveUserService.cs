using BuhUchetApi.DataBase;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.UserServices.RemoveUser
{
    public class RemoveUserService
    {
        private readonly ApplicationContext _dbContext;

        public RemoveUserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<string>> Delete(Guid userId)
        {
            var useracc = await _dbContext.Accounts
              .Include(c => c.Employee)
              .FirstOrDefaultAsync(c => c.Id == userId);

            if (useracc == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Не найден пользователь с идентификатором " + userId.ToString(),
                    Content = null
                };
            }
            else
            {
                try
                {
                    var purpose = await _dbContext.Purposes.Include(u => u.Employee).FirstOrDefaultAsync(c => c.Employee.Id == useracc.Employee.Id);
                    _dbContext.Purposes.Remove(purpose);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Не удалось удалить пользователя. " + ex.Message,
                        Content = null
                    };
                }

                try
                {
                    _dbContext.Employees.Remove(useracc.Employee);
                    _dbContext.Accounts.Remove(useracc);
                    await _dbContext.SaveChangesAsync();

                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Успешное удаление пользователя",
                        Content = null
                    };
                }
                catch(Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Не удалось удалить пользователя. " + ex.Message,
                        Content = null
                    };
                }
                
            }

        }
    }
}
