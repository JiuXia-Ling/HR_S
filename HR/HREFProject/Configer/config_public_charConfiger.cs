using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class config_public_charConfiger:EntityTypeConfiguration<config_public_char>
    {
        public config_public_charConfiger()
        {
            this.ToTable("config_public_char");
            this.HasKey(e => e.pbc_id);
            this.Property(e => e.pbc_id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(e => e.attribute_kind).IsOptional();
            this.Property(e => e.attribute_kind).HasMaxLength(4);
            this.Property(e => e.attribute_kind).HasColumnType("char");
            this.Property(e => e.attribute_name).HasColumnType("varchar");
            this.Property(e => e.attribute_name).HasMaxLength(60);
            this.Property(e => e.attribute_name).IsOptional();
        }
    }
}
