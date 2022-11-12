using Microsoft.EntityFrameworkCore;
using OBioTech.Models;

namespace AnalysisRegister.DataBase
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
        {

        }

        public DbSet<RegisterResult> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=analysisDb;Port=5432;Username=admin;Password=123456");
    }
}