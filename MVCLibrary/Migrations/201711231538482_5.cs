namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Book", new[] { "User_Id" });
            DropColumn("dbo.Book", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Book", "User_Id");
        }
    }
}
