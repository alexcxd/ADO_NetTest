namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remarks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Remarks", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Remarks");
        }
    }
}
