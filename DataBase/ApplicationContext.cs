using BuhUchetApi.Common;
using BuhUchetApi.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BuhUchetApi.DataBase
{
    public class ApplicationContext :DbContext
    {
        private readonly ConnectionStrings _settings;
        public ApplicationContext(IOptions<ConnectionStrings> options) => _settings = options.Value;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditAtribut> AuditAtributs { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<DepreciationAct> DepreciationActs { get; set; }
        public DbSet<DepreciationActPosition> DepreciationActPositions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentPosition> documentPositions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mol> Mols { get; set; }
        public DbSet<Os> Oss { get; set; }
        public DbSet<OsGroup> OsGroups { get; set; }
        public DbSet<OsName> OsNames { get; set; }
        public DbSet<OsParametr> OsParametrs { get; set; }
        public DbSet<OsState> OsStates { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ValueOsParametr> ValueOsParametrs { get; set; }
        public DbSet<ValueOsState> ValueOsStates { get; set; }
        public DbSet<ActType> ActTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(c => c.Id);
            modelBuilder.Entity<Audit>().HasKey(c => c.Id);
            modelBuilder.Entity<AuditAtribut>().HasKey(c => c.Id);
            modelBuilder.Entity<Departament>().HasKey(c => c.Id);
            modelBuilder.Entity<DepreciationAct>().HasKey(c => c.Id);
            modelBuilder.Entity<DepreciationActPosition>().HasKey(c => c.Id);
            modelBuilder.Entity<Document>().HasKey(c => c.Id);
            modelBuilder.Entity<DocumentPosition>().HasKey(c => c.Id);
            modelBuilder.Entity<Employee>().HasKey(c => c.Id);
            modelBuilder.Entity<Mol>().HasKey(c => c.Id);
            modelBuilder.Entity<Os>().HasKey(c => c.Id);
            modelBuilder.Entity<OsGroup>().HasKey(c => c.Id);
            modelBuilder.Entity<OsName>().HasKey(c => c.Id);
            modelBuilder.Entity<OsParametr>().HasKey(c => c.Id);
            modelBuilder.Entity<OsState>().HasKey(c => c.Id);
            modelBuilder.Entity<Post>().HasKey(c => c.Id);
            modelBuilder.Entity<Purpose>().HasKey(c => c.Id);
            modelBuilder.Entity<UserRole>().HasKey(c => c.Id);
            modelBuilder.Entity<ValueOsParametr>().HasKey(c => c.Id);
            modelBuilder.Entity<ValueOsState>().HasKey(c => c.Id);
            modelBuilder.Entity<ActType>().HasKey(c => c.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.DefaultConnection);
        }
    }
}
