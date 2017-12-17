namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QueueBook", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.User", "QueueBook_Id", "dbo.QueueBook");
            DropIndex("dbo.User", new[] { "QueueBook_Id" });
            DropIndex("dbo.QueueBook", new[] { "Book_Id" });
            DropColumn("dbo.User", "QueueBook_Id");
            DropTable("dbo.QueueBook");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QueueBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "QueueBook_Id", c => c.Int());
            CreateIndex("dbo.QueueBook", "Book_Id");
            CreateIndex("dbo.User", "QueueBook_Id");
            AddForeignKey("dbo.User", "QueueBook_Id", "dbo.QueueBook", "Id");
            AddForeignKey("dbo.QueueBook", "Book_Id", "dbo.Book", "Id");
        }
    }
}
