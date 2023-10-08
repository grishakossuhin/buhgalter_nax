using BuhUchetApi.DataBase;
using BuhUchetApi.DataBase.Entities;
using System;
using System.Threading.Tasks;

namespace BuhUchetApi.Services.AuditServices
{
    public class AuditService
    {
        private readonly ApplicationContext _dbContext;
        private readonly Employee _employee;

        public AuditService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ActionAudit(string action, string obj)
        {
            var audit = new Audit()
            {
                Action = action,
                Object = obj,
                Date = DateTime.Now,
                Employee = _employee
            };

            try
            {
                await _dbContext.Audits.AddAsync(audit);
                await _dbContext.SaveChangesAsync();
            }
            catch { }
            return;
        }

        public async Task AtributAudit(string atribut, string oldValue, string newValue)
        {
            var audit = new AuditAtribut()
            {
                Atribut = atribut,
                Date = DateTime.Now,
                Employee = _employee,
                OldValue = oldValue,
                NewValue = newValue
            };

            try
            {
                await _dbContext.AuditAtributs.AddAsync(audit);
                await _dbContext.SaveChangesAsync();
            }
            catch { }
            return;
        }
    }
}
