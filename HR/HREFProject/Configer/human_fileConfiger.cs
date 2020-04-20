using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    public class human_fileConfiger : EntityTypeConfiguration<human_file>
    {
        public human_fileConfiger()
        {
            this.ToTable("human_file");
            this.HasKey(e => e.huf_id);
            this.Property(e => e.human_id).IsOptional().IsUnicode(false).HasMaxLength(30);
            this.Property(e => e.first_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(30);
            this.Property(e => e.first_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.second_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(30);
            this.Property(e => e.second_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.third_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(30);
            this.Property(e => e.third_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.salary_standard_id).IsOptional().IsUnicode(false).HasMaxLength(30);
            this.Property(e => e.salary_standard_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.salary_sum).IsOptional().HasColumnType("money");
            this.Property(e => e.demand_salaray_sum).IsOptional().HasColumnType("money");
            this.Property(e => e.paid_salary_sum).IsOptional().HasColumnType("money");
            this.Property(e => e.check_status).HasColumnType("int");
        }
    }
}
