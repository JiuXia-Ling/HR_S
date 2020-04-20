using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class salary_standard_detailsConfiger: EntityTypeConfiguration<salary_standard_details>
    {
        public salary_standard_detailsConfiger()
        {
            this.ToTable("salary_standard_details");
            this.HasKey(e => e.sdt_id);
            this.Property(e => e.sdt_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.standard_id).HasMaxLength(30);
            this.Property(e => e.standard_id).IsOptional();
            this.Property(e => e.standard_name).HasMaxLength(60);
            this.Property(e => e.standard_name).IsOptional();
            this.Property(e => e.item_id).IsOptional();
            this.Property(e => e.item_name).HasMaxLength(60);
            this.Property(e => e.item_name).IsOptional();
            this.Property(e => e.salary).IsOptional();
            this.HasRequired(e => e.salar_standard_item).WithMany().HasForeignKey(e => e.item_id);

        }
    }
}
