using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.MainThingModels;
using BuhUchetApi.Services.Amortization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.MainThingServices
{
    public class CreateMainThingService
    {
        private readonly ApplicationContext _dbContext;
        private readonly AmortizationService _amortizationService;

        public CreateMainThingService(ApplicationContext dbContext, AmortizationService amortizationService)
        {
            _amortizationService = amortizationService;
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

                var name = await _dbContext.OsNames.FirstOrDefaultAsync(c => c.Id == request.NameId);
                if (name == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = $"Не найдено название {request.NameId} в справочнике"
                    };
                }

                var mol = await _dbContext.Mols.FirstOrDefaultAsync(c => c.Id == request.MolId);
                if (mol == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = $"Не найдено МОЛ {request.MolId} в справочнике"
                    };
                }

                var group = await _dbContext.OsGroups.FirstOrDefaultAsync(c => c.Id == request.GroupId);
                if (group == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = $"Не найдена Группа {request.GroupId} в справочнике"
                    };
                }

                var sender = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == request.SenderId);
                if (sender == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = $"Не найдена сотрудник {request.SenderId} в справочнике"
                    };
                }

                var recep = await _dbContext.Employees.FirstOrDefaultAsync(c => c.Id == request.RecepiantId);
                if (recep == null)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = $"Не найдена сотрудник {request.RecepiantId} в справочнике"
                    };
                }

                var mainThing = new Os();
                mainThing.SerialNumber = request.SerialNumber;
                mainThing.Mol = mol;
                mainThing.OsGroup = group;
                mainThing.OsName = name;
                await _dbContext.Oss.AddAsync(mainThing);
                await _dbContext.SaveChangesAsync();

                var mything = await _dbContext.Oss.FirstOrDefaultAsync(c => c.SerialNumber == request.SerialNumber);
                var document = new Document()
                {
                    Recipient = recep,
                    Sender = sender,
                    Os = mything
                };
                await _dbContext.Documents.AddAsync(document);
                await _dbContext.SaveChangesAsync();

                var amortization = await _amortizationService.GetAmortization(request);
                if (amortization.Success != true)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = $"Ошибки создания амортизации. " + amortization.Message
                    };
                }

                try
                {
                    var state = await _dbContext.OsStates.FirstOrDefaultAsync(c => c.Name == "Ожидает подписания");
                    if (state == null)
                    {
                        return new BaseAnswerVm<string?>()
                        {
                            Success = false,
                            Message = "Не найдено в справочнике состояние \"Ожидает подписания\""
                        };
                    }
                    DateTime endDate = request.StartDate.AddMonths(group.UsefullDate);
                    var value = new ValueOsState()
                    {
                        Os = mything,
                        OsState = state,
                        BeginDate = request.StartDate,
                        EndDate = endDate
                    };
                    await _dbContext.ValueOsStates.AddAsync(value);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string?>()
                    {
                        Success = false,
                        Message = "Ошибка сохранения состояния \"Ожидает подписания\" в базу. " + ex.Message
                    };
                }

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
