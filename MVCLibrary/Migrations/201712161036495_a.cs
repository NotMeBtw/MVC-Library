namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "BorrowLimit", c => c.Int(nullable: false));
            AddColumn("dbo.User", "WaitLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "WaitLimit");
            DropColumn("dbo.User", "BorrowLimit");
        }
    }
}
