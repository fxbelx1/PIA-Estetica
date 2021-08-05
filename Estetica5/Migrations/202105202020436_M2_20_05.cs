namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2_20_05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes");
            DropForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios");
            DropIndex("dbo.Citas", new[] { "Empleado_Id" });
            DropIndex("dbo.Citas", new[] { "Servicio_Id" });
            DropPrimaryKey("dbo.Empleadoes");
            DropPrimaryKey("dbo.Servicios");
            AlterColumn("dbo.Citas", "Empleado_Id", c => c.Int());
            AlterColumn("dbo.Citas", "Servicio_Id", c => c.Int());
            AlterColumn("dbo.Empleadoes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Servicios", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Empleadoes", "Id");
            AddPrimaryKey("dbo.Servicios", "Id");
            CreateIndex("dbo.Citas", "Empleado_Id");
            CreateIndex("dbo.Citas", "Servicio_Id");
            AddForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes", "Id");
            AddForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios");
            DropForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes");
            DropIndex("dbo.Citas", new[] { "Servicio_Id" });
            DropIndex("dbo.Citas", new[] { "Empleado_Id" });
            DropPrimaryKey("dbo.Servicios");
            DropPrimaryKey("dbo.Empleadoes");
            AlterColumn("dbo.Servicios", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Empleadoes", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Citas", "Servicio_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Citas", "Empleado_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Servicios", "Id");
            AddPrimaryKey("dbo.Empleadoes", "Id");
            CreateIndex("dbo.Citas", "Servicio_Id");
            CreateIndex("dbo.Citas", "Empleado_Id");
            AddForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios", "Id");
            AddForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes", "Id");
        }
    }
}
