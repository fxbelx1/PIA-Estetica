namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M17_23_05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleadoes", "Clave", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empleadoes", "Clave");
        }
    }
}
