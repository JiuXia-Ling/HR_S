using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    public class config_file_third_kindConfiger:EntityTypeConfiguration<config_file_third_kind>
    {
        public config_file_third_kindConfiger()
        {
            this.ToTable("config_file_third_kind");
            this.HasKey(e => e.ftk_id);
            this.Property(e => e.ftk_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.first_kind_id).HasMaxLength(30);
            this.Property(e => e.first_kind_id).HasColumnType("varchar");
            this.Property(e => e.first_kind_name).HasMaxLength(60);
            this.Property(e => e.first_kind_name).HasColumnType("varchar");
            this.Property(e => e.second_kind_id).HasMaxLength(30);
            this.Property(e => e.second_kind_id).HasColumnType("varchar");
            this.Property(e => e.second_kind_name).HasMaxLength(60);
            this.Property(e => e.second_kind_name).HasColumnType("varchar");
            this.Property(e => e.third_kind_id).HasMaxLength(30);
            this.Property(e => e.third_kind_id).HasColumnType("varchar");
            this.Property(e => e.third_kind_name).HasMaxLength(60);
            this.Property(e => e.third_kind_name).HasColumnType("varchar");
            this.Property(e => e.third_kind_sale_id).HasColumnType("text");
            this.Property(e => e.third_kind_is_retail).HasMaxLength(4);
            this.Property(e => e.third_kind_is_retail).HasColumnType("char");
        }

    }
}
