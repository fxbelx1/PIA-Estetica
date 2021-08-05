namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M10_21_051 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "Id_Servicio", c => c.Int(nullable: false));
            AddColumn("dbo.Citas", "Id_Empleado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Citas", "Id_Empleado");
            DropColumn("dbo.Citas", "Id_Servicio");
        }
    }
}
