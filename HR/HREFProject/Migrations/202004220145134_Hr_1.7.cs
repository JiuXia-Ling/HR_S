namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_17 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.human_file");
            AddColumn("dbo.human_file", "human_address", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.human_file", "human_postcode", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.human_file", "human_pro_designation", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_major_kind_id", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_major_kind_name", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_major_id", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_major_name", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_telephone", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_homephone", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_mobilephone", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_bank", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.human_file", "human_account", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.human_file", "human_qq", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.human_file", "human_email", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_hobby", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.human_file", "human_specility", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.human_file", "human_sex", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.human_file", "human_religion", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_party", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_nationality", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_race", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_birthday", c => c.DateTime());
            AddColumn("dbo.human_file", "human_birthplace", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.human_file", "human_age", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.human_file", "human_educated_degree", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_educated_years", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.human_file", "human_educated_major", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "human_society_security_id", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.human_file", "human_idcard", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "remark", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.human_file", "major_change_amount", c => c.Short());
            AddColumn("dbo.human_file", "bonus_amount", c => c.Short());
            AddColumn("dbo.human_file", "training_amount", c => c.Short());
            AddColumn("dbo.human_file", "file_chang_amount", c => c.Short());
            AddColumn("dbo.human_file", "human_histroy_records", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.human_file", "human_family_membership", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.human_file", "human_picture", c => c.String(maxLength: 255, unicode: false));
            AddColumn("dbo.human_file", "attachment_name", c => c.String(maxLength: 255, unicode: false));
            AddColumn("dbo.human_file", "register", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "checker", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "changer", c => c.String(maxLength: 60, unicode: false));
            AddColumn("dbo.human_file", "regist_time", c => c.DateTime());
            AddColumn("dbo.human_file", "check_time", c => c.DateTime());
            AddColumn("dbo.human_file", "change_time", c => c.DateTime());
            AddColumn("dbo.human_file", "lastly_change_time", c => c.DateTime());
            AddColumn("dbo.human_file", "delete_time", c => c.DateTime());
            AddColumn("dbo.human_file", "recovery_time", c => c.DateTime());
            AddColumn("dbo.human_file", "human_file_status", c => c.Boolean());
            AddColumn("dbo.human_file", "tiem_statu", c => c.Int());
            AlterColumn("dbo.human_file", "huf_id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.human_file", "first_kind_id", c => c.String(maxLength: 60, unicode: false));
            AlterColumn("dbo.human_file", "second_kind_id", c => c.String(maxLength: 60, unicode: false));
            AlterColumn("dbo.human_file", "third_kind_id", c => c.String(maxLength: 60, unicode: false));
            AlterColumn("dbo.human_file", "salary_sum", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.human_file", "demand_salaray_sum", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.human_file", "paid_salary_sum", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.human_file", "check_status", c => c.String(maxLength: 8000, unicode: false));
            AddPrimaryKey("dbo.human_file", "huf_id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.human_file");
            AlterColumn("dbo.human_file", "check_status", c => c.Int());
            AlterColumn("dbo.human_file", "paid_salary_sum", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.human_file", "demand_salaray_sum", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.human_file", "salary_sum", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.human_file", "third_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.human_file", "second_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.human_file", "first_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.human_file", "huf_id", c => c.Short(nullable: false, identity: true));
            DropColumn("dbo.human_file", "tiem_statu");
            DropColumn("dbo.human_file", "human_file_status");
            DropColumn("dbo.human_file", "recovery_time");
            DropColumn("dbo.human_file", "delete_time");
            DropColumn("dbo.human_file", "lastly_change_time");
            DropColumn("dbo.human_file", "change_time");
            DropColumn("dbo.human_file", "check_time");
            DropColumn("dbo.human_file", "regist_time");
            DropColumn("dbo.human_file", "changer");
            DropColumn("dbo.human_file", "checker");
            DropColumn("dbo.human_file", "register");
            DropColumn("dbo.human_file", "attachment_name");
            DropColumn("dbo.human_file", "human_picture");
            DropColumn("dbo.human_file", "human_family_membership");
            DropColumn("dbo.human_file", "human_histroy_records");
            DropColumn("dbo.human_file", "file_chang_amount");
            DropColumn("dbo.human_file", "training_amount");
            DropColumn("dbo.human_file", "bonus_amount");
            DropColumn("dbo.human_file", "major_change_amount");
            DropColumn("dbo.human_file", "remark");
            DropColumn("dbo.human_file", "human_idcard");
            DropColumn("dbo.human_file", "human_society_security_id");
            DropColumn("dbo.human_file", "human_educated_major");
            DropColumn("dbo.human_file", "human_educated_years");
            DropColumn("dbo.human_file", "human_educated_degree");
            DropColumn("dbo.human_file", "human_age");
            DropColumn("dbo.human_file", "human_birthplace");
            DropColumn("dbo.human_file", "human_birthday");
            DropColumn("dbo.human_file", "human_race");
            DropColumn("dbo.human_file", "human_nationality");
            DropColumn("dbo.human_file", "human_party");
            DropColumn("dbo.human_file", "human_religion");
            DropColumn("dbo.human_file", "human_sex");
            DropColumn("dbo.human_file", "human_specility");
            DropColumn("dbo.human_file", "human_hobby");
            DropColumn("dbo.human_file", "human_email");
            DropColumn("dbo.human_file", "human_qq");
            DropColumn("dbo.human_file", "human_account");
            DropColumn("dbo.human_file", "human_bank");
            DropColumn("dbo.human_file", "human_mobilephone");
            DropColumn("dbo.human_file", "human_homephone");
            DropColumn("dbo.human_file", "human_telephone");
            DropColumn("dbo.human_file", "human_major_name");
            DropColumn("dbo.human_file", "human_major_id");
            DropColumn("dbo.human_file", "human_major_kind_name");
            DropColumn("dbo.human_file", "human_major_kind_id");
            DropColumn("dbo.human_file", "human_pro_designation");
            DropColumn("dbo.human_file", "human_postcode");
            DropColumn("dbo.human_file", "human_address");
            AddPrimaryKey("dbo.human_file", "huf_id");
        }
    }
}
