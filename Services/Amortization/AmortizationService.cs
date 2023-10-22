using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.MainThingModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.Amortization
{
    public class AmortizationService
    {
        private readonly ApplicationContext _dbContext;
        public AmortizationService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BaseAnswerVm<string?>> GetAmortization(CreationOsDto request)
        {
            var datenow = DateTime.Now;
            int monthCount = 1;
            for (var date = request.CreationDate; date <= datenow; date.AddMonths(1))
            {
                monthCount += 1;
            }
            var amortMonth = request.StartPrice / monthCount;

            double oststoim = request.StartPrice - amortMonth * monthCount;
            double nachslIznos = (amortMonth * monthCount) / request.StartPrice * 100;

            var os = await _dbContext.Oss.Include(u => u.OsGroup).FirstOrDefaultAsync(c => c.SerialNumber == request.SerialNumber);
            DateTime endDate = request.StartDate.AddMonths(os.OsGroup.UsefullDate);
            try
            {
                var dir = await _dbContext.OsParametrs.FirstOrDefaultAsync(c => c.Name == "Первоначальная стоимость");
                if (dir == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = "Не найден в справочнике параметр \"Первоначальная стоимость\""
                    };
                }
                var value = new ValueOsParametr()
                {
                    Os = os,
                    OsParametr = dir,
                    BeginDate = request.StartDate,
                    EndDate = endDate,
                    Value = request.StartPrice
                };
                await _dbContext.ValueOsParametrs.AddAsync(value);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string?>()
                {
                    Success = false,
                    Message = "Ошибка сохранения параметра \"Первоначальная стоимость\" в базу. " + ex.Message
                };
            }

            try
            {
                var dir = await _dbContext.OsParametrs.FirstOrDefaultAsync(c => c.Name == "Остаточная стоимость");
                if (dir == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = "Не найден в справочнике параметр \"Остаточная стоимость\""
                    };
                }

                var value = new ValueOsParametr()
                {
                    Os = os,
                    OsParametr = dir,
                    BeginDate = request.StartDate,
                    EndDate = endDate,
                    Value = oststoim
                };
                await _dbContext.ValueOsParametrs.AddAsync(value);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string?>()
                {
                    Success = false,
                    Message = "Ошибка сохранения параметра \"Остаточная стоимость\" в базу. " + ex.Message
                };
            }

            try
            {
                var dir = await _dbContext.OsParametrs.FirstOrDefaultAsync(c => c.Name == "Начисленный износ");
                if (dir == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = "Не найден в справочнике параметр \"Начисленный износ\""
                    };
                }
                var value = new ValueOsParametr()
                {
                    Os = os,
                    OsParametr = dir,
                    BeginDate = request.StartDate,
                    EndDate = endDate,
                    Value = nachslIznos
                };
                await _dbContext.ValueOsParametrs.AddAsync(value);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string?>()
                {
                    Success = false,
                    Message = "Ошибка сохранения параметра \"Начисленный износ\" в базу. " + ex.Message
                };
            }

            try
            {
                var act = new DepreciationAct()
                {
                    Date = endDate,
                    SummMonth = amortMonth,
                    Os = os
                };

                await _dbContext.DepreciationActs.AddAsync(act);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string?>()
                {
                    Success = false,
                    Message = "Ошибка сохранения акта амортизации в базу. " + ex.Message
                };
            }

            return new BaseAnswerVm<string?>()
            {
                Success = true,
                Message = "Успешное создание акта амортизации"
            };
        }

    }
}
