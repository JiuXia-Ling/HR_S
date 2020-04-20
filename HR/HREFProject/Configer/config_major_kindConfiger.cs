using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class config_major_kindConfiger:EntityTypeConfiguration<config_major_kind>
    {
        public config_major_kindConfiger()
        {
            this.ToTable("config_major_kind");
            this.HasKey(e => e.mfk_id);
            this.Property(e => e.mfk_id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(e => e.major_kind_id).IsOptional();
            this.Property(e => e.major_kind_id).HasMaxLength(2);
            this.Property(e => e.major_kind_id).HasColumnType("char");
            this.Property(e => e.major_kind_name).IsOptional();
            this.Property(e => e.major_kind_name).HasMaxLength(60);
            this.Property(e => e.major_kind_name).HasColumnType("varchar");
        }
    }
}
