namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.Book_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Book", "Book_Id", c => c.Int());
            CreateIndex("dbo.Book", "Book_Id");
            AddForeignKey("dbo.Book", "Book_Id", "dbo.Book", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Queue", "User_Id", "dbo.User");
            DropForeignKey("dbo.Queue", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.Book", "Book_Id", "dbo.Book");
            DropIndex("dbo.Queue", new[] { "User_Id" });
            DropIndex("dbo.Queue", new[] { "Book_Id" });
            DropIndex("dbo.Book", new[] { "Book_Id" });
            DropColumn("dbo.Book", "Book_Id");
            DropTable("dbo.Queue");
        }
    }
}
