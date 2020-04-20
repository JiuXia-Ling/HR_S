using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace HREFProject.Configer
{
    class salar_standard_itemConfiger:EntityTypeConfiguration<salar_standard_item>
    {
        public salar_standard_itemConfiger()
        {
            this.ToTable("salar_standard_item");
            this.HasKey(e => e.item_id);
            this.Property(e => e.item_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.Myitem_name).HasMaxLength(60);
            this.Property(e => e.Myitem_name).IsOptional();
        }
    }
}
