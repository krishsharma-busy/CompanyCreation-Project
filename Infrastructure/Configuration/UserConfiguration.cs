using System.Data.Entity.ModelConfiguration;
using Domain.Entity;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            this.ToTable("User");
            this.HasKey(u => u.Id);
            this.Property(u => u.Id).HasColumnName("pk_user_id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(u => u.Name).HasColumnName("user_name").IsRequired().HasMaxLength(100);
            this.Property(u => u.Password).HasColumnName("user_password").IsRequired().HasMaxLength(255);
            this.Property(u => u.CompanyId).HasColumnName("fk_comp_id");
        }
    }
}
