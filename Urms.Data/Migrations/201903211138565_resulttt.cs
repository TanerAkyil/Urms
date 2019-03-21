namespace Urms.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resulttt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Results", "Visa", c => c.Double(nullable: false));
            AlterColumn("dbo.Results", "Final", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Results", "Final", c => c.String(nullable: false));
            AlterColumn("dbo.Results", "Visa", c => c.String(nullable: false));
        }
    }
}
