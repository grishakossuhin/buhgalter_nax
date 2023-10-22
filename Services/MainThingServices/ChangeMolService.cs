using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.MainThingServices
{
    public class ChangeMolService
    {
        private readonly ApplicationContext _dbContext;

        public ChangeMolService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        //НУжНО ДоДЕлАТь!
        public async Task<BaseAnswerVm<string>> ChangeMol(Guid employeeId, Guid osId)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == employeeId);
            if (employee == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не найден сотрудник {employeeId} в справочнике"
                };
            }

            var document = await _dbContext.Documents.Include(u => u.Os).FirstOrDefaultAsync(c => c.Os.Id == osId);
            if (document == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не найден документ {document} в базе"
                };
            }

            try
            {
                document.Recipient = employee;
                await _dbContext.SaveChangesAsync();
                return new BaseAnswerVm<string>()
                {
                    Success = true,
                    Message = $"Успешно изменен МОЛ"
                };
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не удалось изменить МОЛ в ОС. " + ex.Message
                };
            }
        }
    }
}
