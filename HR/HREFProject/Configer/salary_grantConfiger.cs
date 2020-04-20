using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class salary_grantConfiger:EntityTypeConfiguration<salary_grant>
    {
        public salary_grantConfiger()
        {
            this.ToTable("salary_grant");
            this.HasKey(e => e.sgr_id);
            this.Property(e => e.sgr_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.salary_grant_id).HasMaxLength(30);
            this.Property(e => e.salary_grant_id).IsOptional();
            this.Property(e => e.first_kind_id).HasMaxLength(2);
            this.Property(e => e.first_kind_id).IsOptional();
            this.Property(e => e.first_kind_name).HasMaxLength(60);
            this.Property(e => e.first_kind_name).IsOptional();
            this.Property(e => e.second_kind_id).HasMaxLength(2);
            this.Property(e => e.second_kind_id).IsOptional();
            this.Property(e => e.second_kind_name).HasMaxLength(60);
            this.Property(e => e.second_kind_name).IsOptional();
            this.Property(e => e.third_kind_id).HasMaxLength(2);
            this.Property(e => e.third_kind_id).IsOptional();
            this.Property(e => e.third_kind_name).HasMaxLength(2);
            this.Property(e => e.third_kind_name).IsOptional();
            this.Property(e => e.human_amount).IsOptional();
            this.Property(e => e.salary_standard_sum).IsOptional();
            this.Property(e => e.salary_paid_sum).IsOptional(); 
            this.Property(e => e.register).HasMaxLength(60);
            this.Property(e => e.register).IsOptional();
            this.Property(e => e.regist_time).IsOptional();
            this.Property(e => e.checker).HasMaxLength(60);
            this.Property(e => e.checker).IsOptional();
            this.Property(e => e.check_time).IsOptional();
            this.Property(e => e.check_status).IsOptional();
        }
    }
}
