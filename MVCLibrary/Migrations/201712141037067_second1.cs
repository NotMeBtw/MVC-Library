namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tag", "Book_Id", "dbo.Book");
            DropIndex("dbo.Tag", new[] { "Book_Id" });
            DropTable("dbo.Tag");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Tag", "Book_Id");
            AddForeignKey("dbo.Tag", "Book_Id", "dbo.Book", "Id");
        }
    }
}
