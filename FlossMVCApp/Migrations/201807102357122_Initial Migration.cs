namespace FlossMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Floss",
                c => new
                    {
                        FlossId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Skein = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.FlossId)
                .ForeignKey("dbo.Company", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Floss", "CompanyId", "dbo.Company");
            DropIndex("dbo.Floss", new[] { "CompanyId" });
            DropTable("dbo.Floss");
            DropTable("dbo.Company");
        }
    }
}
