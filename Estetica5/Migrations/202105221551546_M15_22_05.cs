namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M15_22_05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "Id_Empleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Citas", "Id_Servicio", "dbo.Servicios");
            DropPrimaryKey("dbo.Empleadoes");
            DropPrimaryKey("dbo.Servicios");
            AlterColumn("dbo.Empleadoes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Servicios", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Empleadoes", "Id");
            AddPrimaryKey("dbo.Servicios", "Id");
            AddForeignKey("dbo.Citas", "Id_Empleado", "dbo.Empleadoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Citas", "Id_Servicio", "dbo.Servicios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "Id_Servicio", "dbo.Servicios");
            DropForeignKey("dbo.Citas", "Id_Empleado", "dbo.Empleadoes");
            DropPrimaryKey("dbo.Servicios");
            DropPrimaryKey("dbo.Empleadoes");
            AlterColumn("dbo.Servicios", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Empleadoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Servicios", "Id");
            AddPrimaryKey("dbo.Empleadoes", "Id");
            AddForeignKey("dbo.Citas", "Id_Servicio", "dbo.Servicios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Citas", "Id_Empleado", "dbo.Empleadoes", "Id", cascadeDelete: true);
        }
    }
}
