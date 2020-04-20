using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    public class config_file_second_kindConfiger:EntityTypeConfiguration<config_file_second_kind>
    {
        public config_file_second_kindConfiger()
        {
            this.ToTable("config_file_second_kind");
            this.HasKey(e => e.fsk_id);
            this.Property(e => e.fsk_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.first_kind_id).HasMaxLength(30);
            this.Property(e => e.first_kind_id).HasColumnType("varchar");
            this.Property(e => e.first_kind_name).HasMaxLength(60);
            this.Property(e => e.first_kind_name).HasColumnType("varchar");
            this.Property(e => e.second_kind_id).HasMaxLength(30);
            this.Property(e => e.second_kind_id).HasColumnType("varchar");
            this.Property(e => e.second_kind_name).HasMaxLength(60);
            this.Property(e => e.second_kind_name).HasColumnType("varchar");
            this.Property(e => e.second_salary_id).HasColumnType("text");
            this.Property(e => e.second_sale_id).HasColumnType("text");
        }
    }
}
