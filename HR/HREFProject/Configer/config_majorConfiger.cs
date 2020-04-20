using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    public class config_majorConfiger:EntityTypeConfiguration<config_major>
    {
        public config_majorConfiger()
        {
            this.ToTable("config_major");
            this.HasKey(e => e.mak_id);
            this.Property(e => e.mak_id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(e => e.major_kind_id).HasMaxLength(4);
            this.Property(e => e.major_kind_id).IsOptional();
            this.Property(e => e.major_kind_id).HasColumnType("char");
            this.Property(e => e.major_kind_name).HasMaxLength(60);
            this.Property(e => e.major_kind_name).IsOptional();
            this.Property(e => e.major_kind_name).HasColumnType("varchar");
            this.Property(e => e.major_id).HasMaxLength(4);
            this.Property(e => e.major_id).HasColumnType("char");
            this.Property(e => e.major_id).IsOptional();
            this.Property(e => e.major_name).HasMaxLength(60);
            this.Property(e => e.major_name).IsOptional();
            this.Property(e => e.major_name).HasColumnType("varchar");
            this.Property(e => e.test_amount).HasColumnType("int");
        }
    }
}
