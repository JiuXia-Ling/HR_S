namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_A12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.human_file",
                c => new
                    {
                        huf_id = c.Short(nullable: false, identity: true),
                        human_id = c.String(maxLength: 30, unicode: false),
                        first_kind_id = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        first_kind_name = c.String(maxLength: 60, unicode: false),
                        second_kind_id = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        second_kind_name = c.String(maxLength: 60, unicode: false),
                        third_kind_id = c.String(maxLength: 2, fixedLength: true, unicode: false),
                        third_kind_name = c.String(maxLength: 60, unicode: false),
                        human_name = c.String(maxLength: 60, unicode: false),
                        salary_standard_id = c.String(maxLength: 30, unicode: false),
                        salary_standard_name = c.String(maxLength: 60, unicode: false),
                        salary_sum = c.Decimal(storeType: "money"),
                        demand_salaray_sum = c.Decimal(storeType: "money"),
                        paid_salary_sum = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.huf_id);
            
            AlterColumn("dbo.salary_standard", "check_time", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.salary_standard", "check_time", c => c.DateTime(nullable: false));
            DropTable("dbo.human_file");
        }
    }
}
