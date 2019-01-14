namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChangeFiledDisplayNameTodisplay_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "display_name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "display_name");
        }
    }
}
