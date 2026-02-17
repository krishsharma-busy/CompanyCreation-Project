using System.Data.Entity;
using Domain.Entity;
using Infrastructure.Configuration;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=CompanyDB")
        {
            // We already created tables via SQL script, so disable EF migrations/initializer
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
        }
    }
}
