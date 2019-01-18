namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddFiledAddTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AddTime", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AddTime");
        }
    }
}
