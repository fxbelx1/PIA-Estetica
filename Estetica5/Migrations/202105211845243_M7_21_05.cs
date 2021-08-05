namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M7_21_05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes");
            DropForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios");
            DropPrimaryKey("dbo.Citas");
            DropPrimaryKey("dbo.Empleadoes");
            DropPrimaryKey("dbo.Servicios");
            AlterColumn("dbo.Citas", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Empleadoes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Servicios", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Citas", "Id");
            AddPrimaryKey("dbo.Empleadoes", "Id");
            AddPrimaryKey("dbo.Servicios", "Id");
            AddForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes", "Id");
            AddForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios", "Id");
            DropColumn("dbo.Citas", "Id_servicio");
            DropColumn("dbo.Citas", "Id_empleado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Citas", "Id_empleado", c => c.Int(nullable: false));
            AddColumn("dbo.Citas", "Id_servicio", c => c.Int(nullable: false));
            DropForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios");
            DropForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes");
            DropPrimaryKey("dbo.Servicios");
            DropPrimaryKey("dbo.Empleadoes");
            DropPrimaryKey("dbo.Citas");
            AlterColumn("dbo.Servicios", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Empleadoes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Citas", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Servicios", "Id");
            AddPrimaryKey("dbo.Empleadoes", "Id");
            AddPrimaryKey("dbo.Citas", "Id");
            AddForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios", "Id");
            AddForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes", "Id");
        }
    }
}
