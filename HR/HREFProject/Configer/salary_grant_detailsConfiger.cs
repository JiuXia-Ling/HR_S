using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class salary_grant_detailsConfiger:EntityTypeConfiguration<salary_grant_details>
    {
        public salary_grant_detailsConfiger()
        {
            this.ToTable("salary_grant_details");
            this.HasKey(e => e.grd_id);
            this.Property(e => e.grd_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.salary_grant_id).HasMaxLength(30);
            this.Property(e => e.salary_grant_id).IsOptional();
            this.Property(e => e.human_id).HasMaxLength(30);
            this.Property(e => e.human_id).IsOptional();
            this.Property(e => e.human_name).HasMaxLength(60);
            this.Property(e => e.human_name).IsOptional(); 
            this.Property(e => e.bouns_sum).IsOptional();
            this.Property(e => e.sale_sum).IsOptional();
            this.Property(e => e.deduct_sum).IsOptional(); 
            this.Property(e => e.salary_standard_sum).IsOptional();
            this.Property(e => e.salary_paid_sum).IsOptional();
            this.Property(e => e.salary_standard_id).IsOptional().IsUnicode(false).HasMaxLength(30);
        }
    }
}
