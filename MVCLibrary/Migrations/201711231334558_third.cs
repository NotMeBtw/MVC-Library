namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Category", name: "RootCategory_Id", newName: "RootCategoryId");
            RenameIndex(table: "dbo.Category", name: "IX_RootCategory_Id", newName: "IX_RootCategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Category", name: "IX_RootCategoryId", newName: "IX_RootCategory_Id");
            RenameColumn(table: "dbo.Category", name: "RootCategoryId", newName: "RootCategory_Id");
        }
    }
}
