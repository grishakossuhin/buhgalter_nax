using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using BuhUchetApi.Models;
using BuhUchetApi.Models.Directories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.Directories
{
    public class GetDirectory
    {
        private readonly ApplicationContext _dbContext;

        public GetDirectory(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task<BaseAnswerVm<List<GetDirectoryVm>>> GetDir(Enums.Directories dir)
        {
            var response = new BaseAnswerVm<List<GetDirectoryVm>>()
            {
                Content = new List<GetDirectoryVm>()
            };
            if (dir == Enums.Directories.MOL)
            {
                try
                {
                    var mols = await _dbContext.Mols.ToListAsync();
                    foreach (var mol in mols)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = mol.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else if (dir == Enums.Directories.Group)
            {
                try
                {
                    var groups = await _dbContext.OsGroups.ToListAsync();
                    foreach (var group in groups)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = group.Name,
                            Spi = group.UsefullDate
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else if (dir == Enums.Directories.Name)
            {
                try
                {
                    var names = await _dbContext.OsNames.ToListAsync();
                    foreach (var name in names)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = name.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else if (dir == Enums.Directories.ActType)
            {
                try
                {
                    var acts = await _dbContext.ActTypes.ToListAsync();
                    foreach (var act in acts)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = act.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }

            else if (dir == Enums.Directories.Post)
            {
                try
                {
                    var posts = await _dbContext.Posts.ToListAsync();
                    foreach (var post in posts)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = post.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else if (dir == Enums.Directories.Departament)
            {
                try
                {
                    var deps = await _dbContext.Departaments.ToListAsync();
                    foreach (var dep in deps)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = dep.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else if (dir == Enums.Directories.Parametr)
            {
                try
                {
                    var parametrs = await _dbContext.OsParametrs.ToListAsync();
                    foreach (var parametr in parametrs)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = parametr.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else if (dir == Enums.Directories.State)
            {
                try
                {
                    var states = await _dbContext.OsStates.ToListAsync();
                    foreach (var state in states)
                    {
                        var ans = new GetDirectoryVm()
                        {
                            Name = state.Name
                        };
                        response.Content.Add(ans);
                    }
                    response.Success = true;
                    response.Message = "Успешное получение справочника";
                    return response;

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Ошибка получения справочника.";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Неверно указан тип справочника";
                return response;
            }
        }
    }
}
