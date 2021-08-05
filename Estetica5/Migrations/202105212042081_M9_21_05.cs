namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M9_21_05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "Hora", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas", "Hora");
        }
    }
}
