namespace Urms.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class result : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "Visa", c => c.String(nullable: false));
            AddColumn("dbo.Results", "Final", c => c.String(nullable: false));
            AddColumn("dbo.Results", "ResitExam", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "ResitExam");
            DropColumn("dbo.Results", "Final");
            DropColumn("dbo.Results", "Visa");
        }
    }
}
