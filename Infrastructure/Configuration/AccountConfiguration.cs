using System.Data.Entity.ModelConfiguration;
using Domain.Entity;

namespace Infrastructure.Configuration
{
    public class AccountConfiguration : EntityTypeConfiguration<AccountEntity>
    {
        public AccountConfiguration()
        {
            this.ToTable("Account");
            this.HasKey(a => a.Id);
            this.Property(a => a.Id).HasColumnName("pk_acc_id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(a => a.Name).HasColumnName("acc_name").IsRequired().HasMaxLength(100);
            this.Property(a => a.Group).HasColumnName("acc_group").HasMaxLength(100);
            this.Property(a => a.Balance).HasColumnName("acc_balance").HasPrecision(18, 2);
            this.Property(a => a.UserId).HasColumnName("fk_user_id");
            this.Property(a => a.CompanyId).HasColumnName("fk_comp_id");
        }
    }
}
