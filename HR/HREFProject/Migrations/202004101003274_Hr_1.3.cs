namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.human_file", "first_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.human_file", "second_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.human_file", "third_kind_id", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.human_file", "third_kind_id", c => c.String(maxLength: 2, fixedLength: true, unicode: false));
            AlterColumn("dbo.human_file", "second_kind_id", c => c.String(maxLength: 2, fixedLength: true, unicode: false));
            AlterColumn("dbo.human_file", "first_kind_id", c => c.String(maxLength: 2, fixedLength: true, unicode: false));
        }
    }
}
