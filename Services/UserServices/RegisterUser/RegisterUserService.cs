using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Services.UserServices.GetFullEmployee;
using Microsoft.EntityFrameworkCore;
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

        public async Task<BaseAnswerVm<FullEmployee>> Register(RegisterRequestDto request)
        {
            var employeeGuid = Guid.NewGuid();
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
                var account = new Account()
                {
                    Username = request.Username,
                    Password = request.Password,
                    Employee = new Employee()
                    {
                        Id = employeeGuid,
                        Firstname = request.Firstname,
                        Secondname = request.Secondname,
                        Thirdname = request.Thirdname,
                        Mol = mol
                    }
                };

                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                var response = new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Ошибка сохранения аккаунта в базу. " + ex.Message
                };
                return response;
            }

            try
            {
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeGuid);

                var puprose = new Purpose()
                {
                    Employee = employee,
                    Post = post,
                    Departament = departament,
                    BeginDate = request.StartDate,
                    EndDate = request.EndDate
                };

                await _dbContext.Purposes.AddAsync(puprose);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var response = new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Ошибка сохранения Назначения в базу. " + ex.Message
                };
                return response;
            }

            var fullemployee = await GetFullEmployee.Getemployee(employeeGuid);
            
            var responseSuccess = new BaseAnswerVm<FullEmployee>()
            {
                Success = false,
                Message = "Успешная регистрация пользователя",
                Content = fullemployee.Content
            };
            return responseSuccess;
        }
    }
}
