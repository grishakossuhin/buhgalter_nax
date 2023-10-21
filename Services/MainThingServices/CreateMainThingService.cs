using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.MainThingModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.MainThingServices
{
    public class CreateMainThingService
    {
        private readonly ApplicationContext _dbContext;

        public CreateMainThingService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<string>> CreateOs(CreationOsDto request)
        {
            if (request == null)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Запрос не может быть пустым",
                    Content = null
                };
            }

            try
            {
                //добавить параметры
                //добавить состояние
                //добавить амортизацию
                var thing = await _dbContext.Oss.FirstOrDefaultAsync(c => c.SerialNumber == request.SerialNumber);
                if (thing != null)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Уже существует ОС с заданным серийным номером",
                        Content = null
                    };
                }

                var mainThing = new Os();

                await _dbContext.Oss.AddAsync(mainThing);
                await _dbContext.SaveChangesAsync();

                return new BaseAnswerVm<string>()
                {
                    Success = true,
                    Message = "ОС успешно создано",
                    Content = null
                };
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Не удалось создать карточу ОС. " + ex.Message,
                    Content = null
                };
            }
            


        }
    }
}
