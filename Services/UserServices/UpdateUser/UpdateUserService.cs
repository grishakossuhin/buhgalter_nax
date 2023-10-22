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

        public async Task<BaseAnswerVm<FullEmployee>> UpdateUser(UpdateUserDto request)
        {
            var account = await _dbContext.Accounts
               .Include(c => c.Employee)
               .FirstOrDefaultAsync(c => c.Id == request.Id);

            if (account == null)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Не найден пользователь с идентификатором " + request.Id.ToString(),
                    Content = null
                };
            }

            var post = await _dbContext.Posts.FirstOrDefaultAsync(c => c.Id == request.Post);
            if (post == null)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = $"Не найдена должность {request.Post} в справочнике",
                    Content = null
                };
            }

            var departament = await _dbContext.Departaments.FirstOrDefaultAsync(c => c.Id == request.Departament);
            if (departament == null)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = $"Не найдено подразделение {request.Departament} в справочнике",
                    Content = null
                };
            }

            var mol = await _dbContext.Mols.FirstOrDefaultAsync(c => c.Id == request.Mol);
            if (mol == null)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = $"Не найдено МОЛ {request.Mol} в справочнике",
                    Content = null
                };
            }

            try
            {
                account.Username = request.Username != account.Username ? request.Username : account.Username;
                account.Password = (request.Password != account.Password && !string.IsNullOrWhiteSpace(request.Password)) ? request.Password : account.Password;
                account.Employee.Firstname = request.Firstname != account.Employee.Firstname ? request.Firstname : account.Employee.Firstname;
                account.Employee.Secondname = request.Secondname != account.Employee.Secondname ? request.Secondname : account.Employee.Secondname;
                account.Employee.Thirdname = request.Thirdname != account.Employee.Thirdname ? request.Thirdname : account.Employee.Thirdname;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Ошибка обновления пользователя. " + ex.Message,
                };
            }

            try
            {
                var purpose = await _dbContext.Purposes
                .Include(u => u.Employee)
                .Include(u => u.Post)
                .Include(u => u.Departament)
                .FirstOrDefaultAsync(c => c.Employee.Id == account.Employee.Id);
                purpose.Post = post;
                purpose.Departament = departament;
                purpose.BeginDate = request.StartDate;
                purpose.EndDate = request.EndDate;
                await _dbContext.SaveChangesAsync();

                
            }
            catch(Exception ex)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Ошибка обновления пользователя. " + ex.Message,
                };
            }

            var fullemployee = await GetFullEmployee.GetFullEmployee.Getemployee(account.Employee.Id);

            var responseSuccess = new BaseAnswerVm<FullEmployee>()
            {
                Success = false,
                Message = "Успешное обновление пользователя",
                Content = fullemployee.Content
            };
            return responseSuccess;

        }
    }
}
