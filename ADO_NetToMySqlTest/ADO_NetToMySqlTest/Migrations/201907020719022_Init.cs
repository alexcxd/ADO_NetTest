namespace ADO_NetToMySqlTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, storeType: "nvarchar"),
                        Url = c.String(maxLength: 100, storeType: "nvarchar"),
                        AddTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.BlogId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100, storeType: "nvarchar"),
                        Content = c.String(maxLength: 100, storeType: "nvarchar"),
                        AddTime = c.DateTime(nullable: false, precision: 0),
                        PageNum = c.Int(nullable: false),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Remark = c.String(maxLength: 100, storeType: "nvarchar"),
                        AddTime = c.DateTime(nullable: false, precision: 0),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        display_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        AddTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "BlogId" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
