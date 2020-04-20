namespace HREFProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hr_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.config_file_second_kind",
                c => new
                    {
                        fsk_id = c.Int(nullable: false, identity: true),
                        second_salary_id = c.String(unicode: false, storeType: "text"),
                        second_sale_id = c.String(unicode: false, storeType: "text"),
                        first_kind_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        first_kind_name = c.String(maxLength: 60, unicode: false),
                        second_kind_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        second_kind_name = c.String(maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.fsk_id);
            
            CreateTable(
                "dbo.config_file_third_kind",
                c => new
                    {
                        ftk_id = c.Int(nullable: false, identity: true),
                        third_kind_sale_id = c.String(unicode: false, storeType: "text"),
                        first_kind_name = c.String(maxLength: 60, unicode: false),
                        second_kind_name = c.String(maxLength: 60, unicode: false),
                        third_kind_name = c.String(maxLength: 60, unicode: false),
                        first_kind_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        second_kind_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        third_kind_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        third_kind_is_retail = c.String(maxLength: 4, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.ftk_id);
            
            CreateTable(
                "dbo.config_major",
                c => new
                    {
                        mak_id = c.Int(nullable: false, identity: true),
                        test_amount = c.Int(nullable: false),
                        major_kind_name = c.String(maxLength: 60, unicode: false),
                        major_name = c.String(maxLength: 60, unicode: false),
                        major_kind_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        major_id = c.String(maxLength: 4, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.mak_id);
            
            CreateTable(
                "dbo.config_major_kind",
                c => new
                    {
                        mfk_id = c.Int(nullable: false, identity: true),
                        major_kind_name = c.String(maxLength: 60, unicode: false),
                        major_kind_id = c.String(maxLength: 2, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.mfk_id);
            
            CreateTable(
                "dbo.config_public_char",
                c => new
                    {
                        pbc_id = c.Int(nullable: false, identity: true),
                        attribute_kind = c.String(maxLength: 4, fixedLength: true, unicode: false),
                        attribute_name = c.String(maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.pbc_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.config_public_char");
            DropTable("dbo.config_major_kind");
            DropTable("dbo.config_major");
            DropTable("dbo.config_file_third_kind");
            DropTable("dbo.config_file_second_kind");
        }
    }
}
