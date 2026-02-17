using System.Data.Entity.ModelConfiguration;
using Domain.Entity;

namespace Infrastructure.Configuration
{
    public class CompanyConfiguration : EntityTypeConfiguration<CompanyEntity>
    {
        public CompanyConfiguration()
        {
            this.ToTable("Company");
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasColumnName("pk_comp_id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.Name).HasColumnName("comp_name").IsRequired().HasMaxLength(255);
            this.Property(c => c.Gstin).HasColumnName("comp_gstin").HasMaxLength(15);
            this.Property(c => c.Country).HasColumnName("comp_country").HasMaxLength(100);
            this.Property(c => c.State).HasColumnName("comp_state").HasMaxLength(100);
        }
    }
}
