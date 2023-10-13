using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.UserServices.UpdateUser
{
    public class UpdateUserService
    {
        private readonly ApplicationContext _dbContext;
        public UpdateUserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<Account>> UpdateUser(UpdateUserDto request)
        {
            var account = await _dbContext.Accounts
               .Include(c => c.Employee)
               .Include(c => c.Employee.Departament)
               .Include(c => c.Employee.Post)
               .Include(c => c.Role)
               .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (account == null)
            {
                return new BaseAnswerVm<Account>()
                {
                    Success = false,
                    Message = "Не найден пользователь с идентификатором " + request.Id.ToString(),
                    Content = null
                };
            }
            try
            {
                account.Username = request.Username != account.Username ? request.Username : account.Username;
                account.Password = request.Password != account.Password ? request.Password : account.Password;
                account.Role.Role = request.Role != account.Role.Role ? request.Role : account.Role.Role;
                account.Employee.Firstname = request.Firstname != account.Employee.Firstname ? request.Firstname : account.Employee.Firstname;
                account.Employee.Secondname = request.Secondname != account.Employee.Secondname ? request.Secondname : account.Employee.Secondname;
                account.Employee.Thirdname = request.Thirdname != account.Employee.Thirdname ? request.Thirdname : account.Employee.Thirdname;
                account.Employee.Departament.Name = request.Departament != account.Employee.Departament.Name ? request.Departament : account.Employee.Departament.Name;
                account.Employee.Post.Name = request.Post != account.Employee.Post.Name ? request.Post : account.Employee.Post.Name;
                await _dbContext.SaveChangesAsync();
                return new BaseAnswerVm<Account>()
                {
                    Success = true,
                    Message = "Успешное обновление пользователя",
                    Content = account
                };
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<Account>()
                {
                    Success = true,
                    Message = "Успешное обновление пользователя",
                    Content = account
                };
            }
        }
    }
}
