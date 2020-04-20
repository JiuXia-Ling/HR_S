using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HREFProject.Configer
{
    class usersConfiger:EntityTypeConfiguration<users>
    {
        public usersConfiger()
        {
            this.ToTable("users");
            this.HasKey(e => e.u_id);
            this.Property(e=>e.u_id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(e => e.u_name).HasMaxLength(60);
            this.Property(e => e.u_name).IsRequired();
            this.Property(e => e.u_password).HasMaxLength(60);
            this.Property(e => e.u_password).HasMaxLength(60);
            this.Property(e => e.u_true_name).IsRequired();
            this.Property(e => e.u_true_name).IsRequired();
        }
    }
    
}
