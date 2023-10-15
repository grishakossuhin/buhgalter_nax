using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models.Directories;
using BuhUchetApi.Models;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace BuhUchetApi.Services.Directories
{
    public class RemoveDirectory
    {
        private readonly ApplicationContext _dbContext;

        public RemoveDirectory(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task<BaseAnswerVm<string>> RemoveDir(RemoveDirectoryDto request)
        {
            if (request.Directory == Enums.Directories.MOL)
            {
                try
                {
                    var mol = await _dbContext.Mols.FirstOrDefaultAsync(c => c.Id == request.Id);
                    
                    if (mol == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.Mols.Remove(mol);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Group)
            {
                try
                {
                    var group = await _dbContext.OsGroups.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (group == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.OsGroups.Remove(group);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Name)
            {
                try
                {
                    var name = await _dbContext.OsNames.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (name == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.OsNames.Remove(name);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.ActType)
            {
                try
                {
                    var act = await _dbContext.ActTypes.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (act == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.ActTypes.Remove(act);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }

            else if (request.Directory == Enums.Directories.Post)
            {
                try
                {
                    var post = await _dbContext.Posts.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (post == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.Posts.Remove(post);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Departament)
            {
                try
                {
                    var dep = await _dbContext.Departaments.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (dep == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.Departaments.Remove(dep);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Parametr)
            {
                try
                {
                    var param = await _dbContext.OsParametrs.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (param == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.OsParametrs.Remove(param);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.State)
            {
                try
                {
                    var state = await _dbContext.OsStates.FirstOrDefaultAsync(c => c.Id == request.Id);

                    if (state == null)
                    {
                        return new BaseAnswerVm<string>()
                        {
                            Success = false,
                            Message = "Не найден справочник с ID =" + request.Id
                        };
                    }
                    _dbContext.OsStates.Remove(state);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно удален"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка удаления справочника. " + ex.Message
                    };
                }
            }
            else
            {
                return new BaseAnswerVm<string>()
                {
                    Success = false,
                    Message = "Неверно указан тип справочника"
                };
            }
        }
    }
}
