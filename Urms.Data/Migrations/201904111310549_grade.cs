namespace Urms.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Results", "graduate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Results", "graduate");
        }
    }
}
