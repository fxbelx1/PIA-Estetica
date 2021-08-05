namespace Estetica5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1_20_05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Empleado_Id = c.String(maxLength: 128),
                        Servicio_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_Id)
                .ForeignKey("dbo.Servicios", t => t.Servicio_Id)
                .Index(t => t.Empleado_Id)
                .Index(t => t.Servicio_Id);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Horario = c.String(),
                        Nombre = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(),
                        Precio = c.Single(nullable: false),
                        Tiempo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "Servicio_Id", "dbo.Servicios");
            DropForeignKey("dbo.Citas", "Empleado_Id", "dbo.Empleadoes");
            DropIndex("dbo.Citas", new[] { "Servicio_Id" });
            DropIndex("dbo.Citas", new[] { "Empleado_Id" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Citas");
        }
    }
}
