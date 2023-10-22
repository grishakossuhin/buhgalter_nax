using BuhUchetApi.DataBase;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.MainThingServices
{
    public class SignOsService
    {
        private readonly ApplicationContext _dbContext;

        public SignOsService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<string>> Sign(Guid id)
        {
            var state = await _dbContext.OsStates.FirstOrDefaultAsync(c => c.Name == "Подписан МОЛ");
            if (state == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Не найдено состояние \"Подписан МОЛ\" в справочнике"
                };
            }

            var osState = await _dbContext.ValueOsStates
                .Include(u => u.Os)
                .Include(u => u.OsState)
                .FirstOrDefaultAsync(c => c.Os.Id == id);
            if (osState == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не найдено значение состояния для ОС {id}"
                };
            }

            try
            {
                osState.OsState = state;
                await _dbContext.SaveChangesAsync();
                return new BaseAnswerVm<string>()
                {
                    Success = true,
                    Message = $"ОС успешно подписан МОЛ"
                };
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = $"Не удалось подписать ОС. " + ex.Message
                };
            }
        }
    }
}
