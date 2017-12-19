namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lend", "IdBook", c => c.Int(nullable: false));
            AddColumn("dbo.Lend", "IdUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lend", "IdUser");
            DropColumn("dbo.Lend", "IdBook");
        }
    }
}
