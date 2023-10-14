using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.MainThingModels;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.MainThingServices
{
    public class CreateMainThingService
    {
        private readonly ApplicationContext _dbContext;
        private readonly GroupInfoService _groupService;

        public CreateMainThingService(ApplicationContext dbContext, GroupInfoService groupInfo)
        {
            _dbContext = dbContext;
            _groupService = groupInfo;
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
                var mainThing = new Os()
                {
                    SerialNumber = request.SerialNumber,
                    ValueOsState = new ValueOsState()
                    {
                        OsState = new OsState()
                        {
                            Name = "Статус документа",
                            Identificator = "DocumentState"
                        },
                        States = Enums.States.Created
                    },
                    OsName = new OsName()
                    {
                        Name = request.Name
                    },
                    Mol = new Mol()
                    {
                        Id = request.MolId,
                    }
                };

                var group = await _groupService.GetInfo(request.Group);
                mainThing.OsGroup.UsefullDate = group.Time;
                mainThing.OsGroup.Name = group.Name;

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
