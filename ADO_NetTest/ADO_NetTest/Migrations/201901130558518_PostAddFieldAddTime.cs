namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostAddFieldAddTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AddTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "AddTime");
        }
    }
}
