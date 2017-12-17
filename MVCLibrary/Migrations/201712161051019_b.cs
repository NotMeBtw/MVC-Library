namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Tags");
        }
    }
}
