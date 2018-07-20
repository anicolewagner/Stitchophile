namespace FlossMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinttostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Floss", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Floss", "Number", c => c.Int(nullable: false));
        }
    }
}
