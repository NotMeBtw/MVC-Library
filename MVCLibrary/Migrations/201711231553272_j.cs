namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "SearchHistory_Id", "dbo.SearchHistory");
            DropForeignKey("dbo.SearchHistory", "User_Id", "dbo.User");
            DropIndex("dbo.Book", new[] { "SearchHistory_Id" });
            DropIndex("dbo.SearchHistory", new[] { "User_Id" });
            DropColumn("dbo.Book", "SearchHistory_Id");
            DropTable("dbo.SearchHistory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SearchHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Book", "SearchHistory_Id", c => c.Int());
            CreateIndex("dbo.SearchHistory", "User_Id");
            CreateIndex("dbo.Book", "SearchHistory_Id");
            AddForeignKey("dbo.SearchHistory", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Book", "SearchHistory_Id", "dbo.SearchHistory", "Id");
        }
    }
}
