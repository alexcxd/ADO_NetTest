namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogDeteleFiledRemarks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blogs", "Remarks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Remarks", c => c.String(maxLength: 100));
        }
    }
}
