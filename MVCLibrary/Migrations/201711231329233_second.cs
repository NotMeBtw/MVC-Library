namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Borrowing", newName: "Lend");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Lend", newName: "Borrowing");
        }
    }
}
