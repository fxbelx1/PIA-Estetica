namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M10_21_05 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Citas");
            AlterColumn("dbo.Citas", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Citas", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Citas");
            AlterColumn("dbo.Citas", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Citas", "Id");
        }
    }
}
