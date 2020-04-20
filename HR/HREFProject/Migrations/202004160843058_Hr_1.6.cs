namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.human_file", "check_status", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.human_file", "check_status");
        }
    }
}
