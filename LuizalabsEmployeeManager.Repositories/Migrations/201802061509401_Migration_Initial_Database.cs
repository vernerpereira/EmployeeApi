namespace LuizalabsEmployeeManager.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128, unicode: false),
                        PersistDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128, unicode: false),
                        Email = c.String(maxLength: 254, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                        PersistDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "Email" });
            DropIndex("dbo.Department", new[] { "Name" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
