namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M12_21_05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes");
            DropForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios");
            DropIndex("dbo.Citas", new[] { "Empleado_Id" });
            DropIndex("dbo.Citas", new[] { "Servicio_Id" });
            DropColumn("dbo.Citas", "Id_Empleado");
            DropColumn("dbo.Citas", "Id_Servicio");
            RenameColumn(table: "dbo.Citas", name: "Empleado_Id", newName: "Id_Empleado");
            RenameColumn(table: "dbo.Citas", name: "Servicio_Id", newName: "Id_Servicio");
            AlterColumn("dbo.Citas", "Id_Empleado", c => c.Int(nullable: false));
            AlterColumn("dbo.Citas", "Id_Servicio", c => c.Int(nullable: false));
            CreateIndex("dbo.Citas", "Id_Servicio");
            CreateIndex("dbo.Citas", "Id_Empleado");
            AddForeignKey("dbo.Citas", "Id_Empleado", "dbo.Empleadoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Citas", "Id_Servicio", "dbo.Servicios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "Id_Servicio", "dbo.Servicios");
            DropForeignKey("dbo.Citas", "Id_Empleado", "dbo.Empleadoes");
            DropIndex("dbo.Citas", new[] { "Id_Empleado" });
            DropIndex("dbo.Citas", new[] { "Id_Servicio" });
            AlterColumn("dbo.Citas", "Id_Servicio", c => c.Int());
            AlterColumn("dbo.Citas", "Id_Empleado", c => c.Int());
            RenameColumn(table: "dbo.Citas", name: "Id_Servicio", newName: "Servicio_Id");
            RenameColumn(table: "dbo.Citas", name: "Id_Empleado", newName: "Empleado_Id");
            AddColumn("dbo.Citas", "Id_Servicio", c => c.Int(nullable: false));
            AddColumn("dbo.Citas", "Id_Empleado", c => c.Int(nullable: false));
            CreateIndex("dbo.Citas", "Servicio_Id");
            CreateIndex("dbo.Citas", "Empleado_Id");
            AddForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios", "Id");
            AddForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes", "Id");
        }
    }
}
