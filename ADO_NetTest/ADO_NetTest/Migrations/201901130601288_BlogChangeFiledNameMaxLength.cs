namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogChangeFiledNameMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Name", c => c.String());
        }
    }
}
