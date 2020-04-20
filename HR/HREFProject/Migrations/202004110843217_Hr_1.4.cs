namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.config_file_second_kind", "first_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.config_file_second_kind", "second_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.config_file_third_kind", "first_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.config_file_third_kind", "second_kind_id", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.config_file_third_kind", "third_kind_id", c => c.String(maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.config_file_third_kind", "third_kind_id", c => c.String(maxLength: 4, fixedLength: true, unicode: false));
            AlterColumn("dbo.config_file_third_kind", "second_kind_id", c => c.String(maxLength: 4, fixedLength: true, unicode: false));
            AlterColumn("dbo.config_file_third_kind", "first_kind_id", c => c.String(maxLength: 4, fixedLength: true, unicode: false));
            AlterColumn("dbo.config_file_second_kind", "second_kind_id", c => c.String(maxLength: 4, fixedLength: true, unicode: false));
            AlterColumn("dbo.config_file_second_kind", "first_kind_id", c => c.String(maxLength: 4, fixedLength: true, unicode: false));
        }
    }
}
