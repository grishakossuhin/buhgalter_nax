using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.UserServices.GetFullEmployee
{
    public class GetFullEmployee
    {
        private readonly ApplicationContext _dbContext;
        public GetFullEmployee(ApplicationContext context)
        {
            _dbContext = context;
        }

        public static async Task<BaseAnswerVm<FullEmployee>> Getemployee(Guid id)
        {

            try
            {
                var employee = await _dbContext.Employees.Include(u => u.Mol).FirstOrDefaultAsync(c => c.Id == id);
                if (employee == null)
                {
                    return new BaseAnswerVm<FullEmployee>()
                    {
                        Success = false,
                        Message = $"Не найден сотрудник {id} в справочнике",
                        Content = null
                    };
                }

                var purpose = await _dbContext.Purposes
                    .Include(u => u.Departament)
                    .Include(u => u.Post)
                    .Include(u => u.Employee)
                    .FirstOrDefaultAsync(c => c.Employee.Id == employee.Id);
                if (purpose == null)
                {
                    return new BaseAnswerVm<FullEmployee>()
                    {
                        Success = false,
                        Message = $"Не найдено назначение сотрудника {employee.Id} в справочнике",
                        Content = null
                    };
                }

                var fullEmployee = new FullEmployee()
                {
                    Firstname = employee.Firstname,
                    Secondname = employee.Secondname,
                    Thirdname = employee.Thirdname,
                    MolName = employee.Mol.Name,
                    PostName = purpose.Post.Name,
                    DepartamentName = purpose.Departament.Name,
                    StartDate = purpose.BeginDate,
                    EndDate = purpose.EndDate
                };

                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = true,
                    Message = "Успешное получение информации о пользователе",
                    Content = fullEmployee
                };
            }
            catch(Exception ex)
            {
                return new BaseAnswerVm<FullEmployee>()
                {
                    Success = false,
                    Message = "Ошибка чтения данных из базы. " + ex.Message
                };
            }
        }
    }
}
