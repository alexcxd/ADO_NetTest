namespace ADO_NetTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableOrderANDEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        HireDate = c.DateTime(nullable: false),
                        MarId = c.Int(nullable: false),
                        Ssn = c.String(nullable: false, maxLength: 20),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CustId = c.String(nullable: false, maxLength: 10),
                        Orders = c.DateTime(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
        }
    }
}
