using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.Directories;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.Directories
{
    public class AddDirectory
    {
        private readonly ApplicationContext _dbContext;

        public AddDirectory(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task<BaseAnswerVm<string>> AddDir(AddDirectoryDto request)
        {
            if (request.Directory == Enums.Directories.MOL)
            {
                var mol = new Mol()
                {
                    Name = request.Name
                };
                try
                {
                    await _dbContext.Mols.AddAsync(mol);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Group)
            {
                var group = new OsGroup()
                {
                    Name = request.Name,
                    UsefullDate = request.Spi
                };
                try
                {
                    await _dbContext.OsGroups.AddAsync(group);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Name)
            {
                var name = new OsName()
                {
                    Name = request.Name,
                };
                try
                {
                    await _dbContext.OsNames.AddAsync(name);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.ActType)
            {
                var act = new ActType()
                {
                    Name = request.Name,
                };
                try
                {
                    await _dbContext.ActTypes.AddAsync(act);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }

            else if (request.Directory == Enums.Directories.Post)
            {
                var post = new Post()
                {
                    Name = request.Name,
                };
                try
                {
                    await _dbContext.Posts.AddAsync(post);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Departament)
            {
                var dep = new Departament()
                {
                    Name = request.Name,
                };
                try
                {
                    await _dbContext.Departaments.AddAsync(dep);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.Parametr)
            {
                var par = new OsParametr()
                {
                    Name = request.Name,
                };
                try
                {
                    await _dbContext.OsParametrs.AddAsync(par);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
                    };
                }
            }
            else if (request.Directory == Enums.Directories.State)
            {
                var state = new OsState()
                {
                    Name = request.Name,
                };
                try
                {
                    await _dbContext.OsStates.AddAsync(state);
                    await _dbContext.SaveChangesAsync();
                    return new BaseAnswerVm<string>()
                    {
                        Success = true,
                        Message = "Справочник успешно добавлен"
                    };

                }
                catch (Exception ex)
                {
                    return new BaseAnswerVm<string>()
                    {
                        Success = false,
                        Message = "Ошибка добавления справочника. " + ex.Message
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
