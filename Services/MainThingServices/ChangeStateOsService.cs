using BuhUchetApi.DataBase;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.MainThingServices
{
    public class ChangeStateOsService
    {
        private readonly ApplicationContext _dbContext;

        public ChangeStateOsService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<string>> ChangeState(Guid osId, string status)
        {
            var state = await _dbContext.OsStates.FirstOrDefaultAsync(c => c.Name == status);
            if (state == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не найдено состояние \"{state}\" в справочнике"
                };
            }

            var value = await _dbContext.ValueOsStates.Include(u => u.Os).FirstOrDefaultAsync(c => c.Os.Id == osId);
            if (value == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не найдено значение состояния \"{state}\""
                };
            }

            value.OsState = state;
            try
            {
                await _dbContext.SaveChangesAsync();
                return new BaseAnswerVm<string>()
                {
                    Success = true,
                    Message = $"Успешная смена статуса"
                };

            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не удалось сменить статус для ОС {osId}. " + ex.Message
                };
            }
        }
    }
}
