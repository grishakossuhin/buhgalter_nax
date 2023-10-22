using BuhUchetApi.DataBase;
using BuhUchetApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.Amortization
{
    public class UpdateAmortization
    {
        private readonly ApplicationContext _dbContext;

        public UpdateAmortization(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task<BaseAnswerVm<string>> Update(UpdateAmortizationDto request)
        {
            var amort = await _dbContext.DepreciationActs.Include(u => u.Os).FirstOrDefaultAsync(c => c.Id == request.Id);
            amort.SummMonth = request.AmortMonth;
            amort.Date = request.EndDate;
            try
            {
                var value = await _dbContext.ValueOsParametrs
                    .Include(u => u.Os)
                    .Include(u => u.OsParametr)
                    .FirstOrDefaultAsync(c => c.Os.Id == amort.Os.Id && c.OsParametr.Name == "Остаточная стоимость");

                value.Value = request.OstatochnStoim;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Ошибка сохранения параметра \"Остаточная стоимость\" в базу. " + ex.Message
                };
            }

            try
            {
                var value = await _dbContext.ValueOsParametrs
                    .Include(u => u.Os)
                    .Include(u => u.OsParametr)
                    .FirstOrDefaultAsync(c => c.Os.Id == amort.Os.Id && c.OsParametr.Name == "Начисленный износ");

                value.Value = request.NachslIznos;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Ошибка сохранения параметра \"Начисленный износ\" в базу. " + ex.Message
                };
            }

            return new BaseAnswerVm<string>()
            {
                Success = true,
                Message = "Успешное обновление акта амортизации"
            };
        }
    }
}
