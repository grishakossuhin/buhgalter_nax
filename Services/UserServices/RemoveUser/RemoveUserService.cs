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
              .Include(c => c.Employee.Departament)
              .Include(c => c.Employee.Post)
              .Include(c => c.Role)
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
                    _dbContext.Departaments.Remove(useracc.Employee.Departament);
                    _dbContext.UserRoles.Remove(useracc.Role);
                    _dbContext.Posts.Remove(useracc.Employee.Post);
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
