using HREFProject;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Configer
{
    public class human_fileConfiger : EntityTypeConfiguration<human_file>
    {
        public human_fileConfiger()
        {
            this.ToTable("human_file");
            this.HasKey(e => e.huf_id);
            this.Property(e => e.human_id).IsOptional().IsUnicode(false).HasMaxLength(30);
            this.Property(e => e.first_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(60);
            this.Property(e => e.first_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.second_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(60);
            this.Property(e => e.second_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.third_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(60);
            this.Property(e => e.third_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_address).IsOptional().IsUnicode(false).HasMaxLength(200);
            this.Property(e => e.human_postcode).IsOptional().IsUnicode(false).HasMaxLength(10);
            this.Property(e => e.human_pro_designation).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_major_kind_id).IsOptional().HasColumnType("varchar").HasMaxLength(60);
            this.Property(e => e.human_major_kind_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_major_id).IsOptional().HasColumnType("varchar").HasMaxLength(60);
            this.Property(e => e.human_major_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_telephone).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_homephone).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_mobilephone).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_bank).IsOptional().IsUnicode(false).HasMaxLength(50);
            this.Property(e => e.human_account).IsOptional().IsUnicode(false).HasMaxLength(30);
            this.Property(e => e.human_qq).IsOptional().IsUnicode(false).HasMaxLength(15);
            this.Property(e => e.human_email).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_hobby).IsOptional().IsUnicode(false).HasMaxLength(200);
            this.Property(e => e.human_specility).IsOptional().IsUnicode(false).HasMaxLength(200);
            this.Property(e => e.human_sex).IsOptional().HasColumnType("varchar").HasMaxLength(50);
            this.Property(e => e.human_religion).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_party).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_nationality).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_race).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_birthday).IsOptional().HasColumnType("datetime");
            this.Property(e => e.human_birthplace).IsOptional().IsUnicode(false).HasMaxLength(200);
            this.Property(e => e.human_age).IsOptional().HasColumnType("varchar").HasMaxLength(50); ;
            this.Property(e => e.human_educated_degree).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_educated_years).IsOptional().HasColumnType("varchar").HasMaxLength(50); ;
            this.Property(e => e.human_educated_major).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.human_society_security_id).IsOptional().IsUnicode(false).HasMaxLength(30);
            this.Property(e => e.human_idcard).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.remark).IsOptional().HasColumnType("text");
            this.Property(e => e.salary_standard_id).IsOptional().IsUnicode(false).HasMaxLength(30);
            this.Property(e => e.salary_standard_name).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.salary_sum).IsOptional().HasColumnType("decimal");
            this.Property(e => e.demand_salaray_sum).IsOptional().HasColumnType("decimal");
            this.Property(e => e.paid_salary_sum).IsOptional().HasColumnType("decimal");
            this.Property(e => e.major_change_amount).IsOptional().HasColumnType("smallint");
            this.Property(e => e.bonus_amount).IsOptional().HasColumnType("smallint");
            this.Property(e => e.training_amount).IsOptional().HasColumnType("smallint");
            this.Property(e => e.file_chang_amount).IsOptional().HasColumnType("smallint");
            this.Property(e => e.human_histroy_records).IsOptional().HasColumnType("text");
            this.Property(e => e.human_family_membership).IsOptional().HasColumnType("text");
            this.Property(e => e.human_picture).IsOptional().IsUnicode(false).HasMaxLength(255);
            this.Property(e => e.attachment_name).IsOptional().IsUnicode(false).HasMaxLength(255);
            this.Property(e => e.check_status).IsOptional().HasColumnType("varchar");
            this.Property(e => e.register).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.checker).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.changer).IsOptional().IsUnicode(false).HasMaxLength(60);
            this.Property(e => e.regist_time).IsOptional().HasColumnType("datetime");
            this.Property(e => e.check_time).IsOptional().HasColumnType("datetime");
            this.Property(e => e.change_time).IsOptional().HasColumnType("datetime");
            this.Property(e => e.lastly_change_time).IsOptional().HasColumnType("datetime");
            this.Property(e => e.delete_time).IsOptional().HasColumnType("datetime");
            this.Property(e => e.recovery_time).IsOptional().HasColumnType("datetime");
            this.Property(e => e.human_file_status).IsOptional().HasColumnType("bit");
            this.Property(e => e.tiem_statu).IsOptional().HasColumnType("int");
        }
    }
}
