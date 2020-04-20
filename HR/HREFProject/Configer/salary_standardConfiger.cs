using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class salary_standardConfiger:EntityTypeConfiguration<salary_standard>
    {
        public salary_standardConfiger()
        {
            this.ToTable("salary_standard");
            this.HasKey(e => e.ssd_id);
            this.Property(e => e.ssd_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.standard_id).HasMaxLength(30);
            this.Property(e => e.standard_id).IsOptional();
            this.Property(e => e.standard_name).HasMaxLength(60);
            this.Property(e => e.standard_name).IsOptional();
            this.Property(e => e.designer).HasMaxLength(60);
            this.Property(e => e.designer).IsOptional();
            this.Property(e => e.register).HasMaxLength(60);
            this.Property(e => e.register).IsOptional();
            this.Property(e => e.checker).HasMaxLength(60);
            this.Property(e => e.checker).IsOptional(); 
            this.Property(e => e.changer).HasMaxLength(60);
            this.Property(e => e.changer).IsOptional();
            this.Property(e => e.regist_time).IsOptional();
            this.Property(e => e.change_time).IsOptional();
            this.Property(e => e.salary_sum).IsOptional();
            this.Property(e => e.check_status).IsOptional();
            this.Property(e => e.change_status).IsOptional();
            this.Property(e => e.check_comment).IsOptional();
            this.Property(e => e.remark).IsOptional();
        }
    }
}
