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
                    var account = await _dbContext.Accounts.FirstOrDefaultAsync(c => c.Id == userId);
                    var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == userId);
                    var post = await _dbContext.Posts.FirstOrDefaultAsync(c => c.Id == userId);
                    var role = await _dbContext.UserRoles.FirstOrDefaultAsync(c => c.Id == userId);
                    var departament = await _dbContext.Departaments.FirstOrDefaultAsync(c => c.Id == userId);

                    _dbContext.Departaments.Remove(departament);
                    _dbContext.UserRoles.Remove(role);
                    _dbContext.Posts.Remove(post);
                    _dbContext.Employees.Remove(employee);
                    _dbContext.Accounts.Remove(account);

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
