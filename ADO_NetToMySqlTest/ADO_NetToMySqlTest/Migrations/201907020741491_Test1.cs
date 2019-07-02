namespace ADO_NetToMySqlTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "PageNum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PageNum", c => c.Int(nullable: false));
        }
    }
}
