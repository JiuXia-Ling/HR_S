namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.config_file_first_kind",
                c => new
                    {
                        ffk_id = c.Int(nullable: false, identity: true),
                        first_kind_salary_id = c.String(unicode: false, storeType: "text"),
                        first_kind_sale_id = c.String(unicode: false, storeType: "text"),
                        first_kind_name = c.String(maxLength: 60),
                        first_kind_id = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.ffk_id);
            
            CreateTable(
                "dbo.salar_standard_item",
                c => new
                    {
                        item_id = c.Int(nullable: false, identity: true),
                        Myitem_name = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.item_id);
            
            CreateTable(
                "dbo.salary_grant",
                c => new
                    {
                        sgr_id = c.Int(nullable: false, identity: true),
                        human_amount = c.Int(),
                        check_status = c.Int(),
                        salary_standard_sum = c.Decimal(precision: 18, scale: 2),
                        salary_paid_sum = c.Decimal(precision: 18, scale: 2),
                        regist_time = c.DateTime(),
                        check_time = c.DateTime(),
                        salary_grant_id = c.String(maxLength: 30),
                        first_kind_name = c.String(maxLength: 60),
                        second_kind_name = c.String(maxLength: 60),
                        third_kind_name = c.String(maxLength: 2),
                        register = c.String(maxLength: 60),
                        checker = c.String(maxLength: 60),
                        first_kind_id = c.String(maxLength: 2),
                        second_kind_id = c.String(maxLength: 2),
                        third_kind_id = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.sgr_id);
            
            CreateTable(
                "dbo.salary_grant_details",
                c => new
                    {
                        grd_id = c.Int(nullable: false, identity: true),
                        bouns_sum = c.Decimal(precision: 18, scale: 2),
                        sale_sum = c.Decimal(precision: 18, scale: 2),
                        deduct_sum = c.Decimal(precision: 18, scale: 2),
                        salary_standard_sum = c.Decimal(precision: 18, scale: 2),
                        salary_paid_sum = c.Decimal(precision: 18, scale: 2),
                        salary_grant_id = c.String(maxLength: 30),
                        human_id = c.String(maxLength: 30),
                        human_name = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.grd_id);
            
            CreateTable(
                "dbo.salary_standard",
                c => new
                    {
                        ssd_id = c.Int(nullable: false, identity: true),
                        check_comment = c.String(),
                        remark = c.String(),
                        check_status = c.Int(),
                        change_status = c.Int(),
                        salary_sum = c.Decimal(precision: 18, scale: 2),
                        regist_time = c.DateTime(),
                        check_time = c.DateTime(nullable: false),
                        change_time = c.DateTime(),
                        standard_id = c.String(maxLength: 30),
                        standard_name = c.String(maxLength: 60),
                        designer = c.String(maxLength: 60),
                        register = c.String(maxLength: 60),
                        checker = c.String(maxLength: 60),
                        changer = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.ssd_id);
            
            CreateTable(
                "dbo.salary_standard_details",
                c => new
                    {
                        sdt_id = c.Int(nullable: false, identity: true),
                        item_id = c.Int(nullable: false),
                        salary = c.Double(),
                        standard_id = c.String(maxLength: 30),
                        standard_name = c.String(maxLength: 60),
                        item_name = c.String(maxLength: 60),
                        salary_standard_ssd_id = c.Int(),
                    })
                .PrimaryKey(t => t.sdt_id)
                .ForeignKey("dbo.salar_standard_item", t => t.item_id, cascadeDelete: true)
                .ForeignKey("dbo.salary_standard", t => t.salary_standard_ssd_id)
                .Index(t => t.item_id)
                .Index(t => t.salary_standard_ssd_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        u_id = c.Int(nullable: false, identity: true),
                        u_name = c.String(nullable: false, maxLength: 60),
                        u_true_name = c.String(nullable: false),
                        u_password = c.String(maxLength: 60),
                    })
                .PrimaryKey(t => t.u_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.salary_standard_details", "salary_standard_ssd_id", "dbo.salary_standard");
            DropForeignKey("dbo.salary_standard_details", "item_id", "dbo.salar_standard_item");
            DropIndex("dbo.salary_standard_details", new[] { "salary_standard_ssd_id" });
            DropIndex("dbo.salary_standard_details", new[] { "item_id" });
            DropTable("dbo.users");
            DropTable("dbo.salary_standard_details");
            DropTable("dbo.salary_standard");
            DropTable("dbo.salary_grant_details");
            DropTable("dbo.salary_grant");
            DropTable("dbo.salar_standard_item");
            DropTable("dbo.config_file_first_kind");
        }
    }
}
