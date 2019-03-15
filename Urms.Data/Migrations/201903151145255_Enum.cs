namespace Urms.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "smsEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "smsEnum");
        }
    }
}
