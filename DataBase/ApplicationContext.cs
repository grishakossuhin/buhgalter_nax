using BuhUchetApi.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BuhUchetApi.DataBase
{
    public class ApplicationContext :DbContext
    {
        private readonly ConnectionStrings _settings;
        public ApplicationContext(IOptions<ConnectionStrings> options) => _settings = options.Value;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.DefaultConnection);
        }
    }
}
