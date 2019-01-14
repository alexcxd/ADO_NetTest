namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddFiledCountry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Country", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Country");
        }
    }
}
