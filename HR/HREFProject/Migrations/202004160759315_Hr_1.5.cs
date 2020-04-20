namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.salary_grant_details", "salary_standard_id", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.salary_grant_details", "salary_standard_id");
        }
    }
}
