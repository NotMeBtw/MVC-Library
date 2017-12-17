namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Book", "Book_Id", "dbo.Book");
            DropIndex("dbo.Book", new[] { "Book_Id" });
            DropColumn("dbo.Book", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Book_Id", c => c.Int());
            CreateIndex("dbo.Book", "Book_Id");
            AddForeignKey("dbo.Book", "Book_Id", "dbo.Book", "Id");
        }
    }
}
