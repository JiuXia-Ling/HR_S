using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    public class config_file_first_kindConfiger : EntityTypeConfiguration<config_file_first_kind>
    {
        public config_file_first_kindConfiger()
        {
            this.ToTable("config_file_first_kind");
            this.HasKey(e => e.ffk_id);
            this.Property(e => e.ffk_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.first_kind_id).HasMaxLength(4);
            this.Property(e => e.first_kind_id).IsOptional();
            this.Property(e => e.first_kind_name).HasMaxLength(60 );
            this.Property(e => e.first_kind_name).IsOptional();
            this.Property(e => e.first_kind_salary_id).HasColumnType("text");
            this.Property(e => e.first_kind_sale_id).HasColumnType("text");
        }
    }
}
