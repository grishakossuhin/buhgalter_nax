using BuhUchetApi.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUchetApi.Models.MainThingModels
{
    public class GetAllMainThings
    {
        private readonly ApplicationContext _dbContext;

        public GetAllMainThings(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseAnswerVm<List<MainThings>>> GetMainThings()
        {
            try
            {
                var oss = await _dbContext.Oss
                .Include(c => c.OsGroup)
                .Include(c => c.Mol)
                .Include(c => c.OsName)
                .ToArrayAsync();
                var response = new List<MainThings>();

                foreach (var os in oss)
                {
                    var result = new MainThings();
                    result.Serialnumber = os.SerialNumber;
                    result.Id = os.Id;

                    //Группа
                    var group = new MtGroup()
                    {
                        Id = os.OsGroup.Id,
                        Name = os.OsGroup.Name,
                        UsefullDate = os.OsGroup.UsefullDate
                    };
                    result.Group = group;

                    //название
                    var name = new MtName()
                    {
                        Id = os.OsName.Id,
                        Name = os.OsName.Name,
                    };
                    result.Name = name;

                    //МОЛ
                    var molEmployee = await _dbContext.Employees.Include(c => c.Mol).FirstOrDefaultAsync(u => u.Mol.Id == os.Mol.Id);
                    var molPurpose = await _dbContext.Purposes
                        .Include(u => u.Employee)
                        .Include(u => u.Post)
                        .Include(u => u.Departament)
                        .FirstOrDefaultAsync(c => c.Employee.Id == molEmployee.Id);
                    var mol = new MtMol()
                    {
                        Id = os.Mol.Id,
                        Name = os.Mol.Name,
                        Employee = new MtEmployee()
                        {
                            Id = molEmployee.Id,
                            Firstname = molEmployee.Firstname,
                            Secondname = molEmployee.Secondname,
                            Thirdname = molEmployee.Thirdname,
                            Purpose = new MtPurpose()
                            {
                                Id = molPurpose.Id,
                                EndDate = molPurpose.EndDate,
                                StartDate = molPurpose.BeginDate,
                                Post = new MtPost()
                                {
                                    Id = molPurpose.Post.Id,
                                    Name = molPurpose.Post.Name
                                },
                                Departament = new MtDepartament()
                                {
                                    Id = molPurpose.Departament.Id,
                                    Name = molPurpose.Departament.Name
                                }
                            }
                        }
                    };
                    result.Mol = mol;

                    //Документ
                    var doc = await _dbContext.Documents.Include(u => u.Os).Include(u => u.Sender).Include(u => u.Recipient).FirstOrDefaultAsync(c => c.Os.Id == os.Id);

                    var senderEmployee = await _dbContext.Employees.FirstOrDefaultAsync(u => u.Id == doc.Sender.Id);
                    var senderPurpose = await _dbContext.Purposes
                        .Include(u => u.Employee)
                        .Include(u => u.Post)
                        .Include(u => u.Departament)
                        .FirstOrDefaultAsync(c => c.Employee.Id == senderEmployee.Id);
                    var recepianEmployee = await _dbContext.Employees.FirstOrDefaultAsync(u => u.Id == doc.Recipient.Id);
                    var recepianPurpose = await _dbContext.Purposes
                        .Include(u => u.Employee)
                        .Include(u => u.Post)
                        .Include(u => u.Departament)
                        .FirstOrDefaultAsync(c => c.Employee.Id == recepianEmployee.Id);
                    var document = new MtDocument()
                    {
                        Id = doc.Id,
                        Sender = new MtEmployee()
                        {
                            Firstname = senderEmployee.Firstname,
                            Secondname = senderEmployee.Secondname,
                            Thirdname = senderEmployee.Thirdname,
                            Id = senderEmployee.Id,
                            Purpose = new MtPurpose()
                            {
                                Id = senderPurpose.Id,
                                StartDate = senderPurpose.BeginDate,
                                EndDate = senderPurpose.EndDate,
                                Departament = new MtDepartament()
                                {
                                    Id = senderPurpose.Departament.Id,
                                    Name = senderPurpose.Departament.Name,
                                },
                                Post = new MtPost()
                                {
                                    Id = senderPurpose.Post.Id,
                                    Name = senderPurpose.Post.Name,
                                }
                            }
                        },
                        Recepiant = new MtEmployee()
                        {
                            Firstname = recepianEmployee.Firstname,
                            Secondname = recepianEmployee.Secondname,
                            Thirdname = recepianEmployee.Thirdname,
                            Id = recepianEmployee.Id,
                            Purpose = new MtPurpose()
                            {
                                Id = recepianPurpose.Id,
                                StartDate = recepianPurpose.BeginDate,
                                EndDate = recepianPurpose.EndDate,
                                Departament = new MtDepartament()
                                {
                                    Id = recepianPurpose.Departament.Id,
                                    Name = recepianPurpose.Departament.Name,
                                },
                                Post = new MtPost()
                                {
                                    Id = recepianPurpose.Post.Id,
                                    Name = recepianPurpose.Post.Name,
                                }
                            }
                        }
                    };
                    result.Document = document;

                    //Состояние
                    var valstate = await _dbContext.ValueOsStates
                        .Include(u => u.Os)
                        .Include(u => u.OsState)
                        .FirstOrDefaultAsync(c => c.Os.Id == os.Id);
                    var state = new MtValueState()
                    {
                        BeginDate = valstate.BeginDate,
                        EndDate = valstate.EndDate,
                        Id = valstate.Id,
                        Name = new MtState()
                        {
                            Id = valstate.OsState.Id,
                            Name = valstate.OsState.Name,
                        }
                    };
                    result.State = state;

                    //Амортизация
                    var amort = await _dbContext.DepreciationActs.Include(u => u.Os).FirstOrDefaultAsync(c => c.Os.Id == os.Id);
                    var amortization = new MtAmortization()
                    {
                        Id = amort.Id,
                        Date = amort.Date,
                        SummMonth = amort.SummMonth
                    };
                    result.Amortization = amortization;

                    //параметры
                    var paramms = await _dbContext.ValueOsParametrs
                        .Include(u => u.Os)
                        .Include(u => u.OsParametr)
                        .Where(c => c.Os.Id == os.Id)
                        .ToListAsync();

                    var parametrs = new List<MtValueParametr>();
                    foreach (var prm in paramms)
                    {
                        var param = new MtValueParametr()
                        {
                            Id = prm.Id,
                            BeginDate = prm.BeginDate,
                            EndDate = prm.EndDate,
                            Value = prm.Value,
                            Name = new MtParametr()
                            {
                                Id = prm.OsParametr.Id,
                                Name = prm.OsParametr.Name
                            }
                        };
                        parametrs.Add(param);
                    }
                    result.Parametrs = parametrs;
                    response.Add(result);
                }

                return new BaseAnswerVm<List<MainThings>>()
                {
                    Success = true,
                    Message = "Успешное получение основных средств",
                    Content = response
                };
            }
            catch (Exception ex)
            {
                return new BaseAnswerVm<List<MainThings>>()
                {
                    Success = false,
                    Message = "Не удалось получить список ОС"
                };
            }
            
        }
    }
}
