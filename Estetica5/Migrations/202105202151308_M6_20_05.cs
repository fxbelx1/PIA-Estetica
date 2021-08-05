namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M6_20_05 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "Id_servicio", c => c.Int(nullable: false));
            AddColumn("dbo.Citas", "Id_empleado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas", "Id_empleado");
            DropColumn("dbo.Citas", "Id_servicio");
        }
    }
}
