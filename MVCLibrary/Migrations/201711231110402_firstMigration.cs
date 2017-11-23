namespace MVCLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        ISBN = c.String(),
                        Available = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                        SearchHistory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.SearchHistory", t => t.SearchHistory_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id)
                .Index(t => t.SearchHistory_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RootCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.RootCategory_Id)
                .Index(t => t.RootCategory_Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Borrowing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateBorrowed = c.DateTime(nullable: false),
                        DateReturn = c.DateTime(nullable: false),
                        State = c.String(),
                        Book_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.Book_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        QueueBook_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QueueBook", t => t.QueueBook_Id)
                .Index(t => t.QueueBook_Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.QueueBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.SearchHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.SearchHistory", "User_Id", "dbo.User");
            DropForeignKey("dbo.Book", "SearchHistory_Id", "dbo.SearchHistory");
            DropForeignKey("dbo.User", "QueueBook_Id", "dbo.QueueBook");
            DropForeignKey("dbo.QueueBook", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.Borrowing", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.IdentityUserLogin", "User_Id", "dbo.User");
            DropForeignKey("dbo.IdentityUserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Book", "User_Id", "dbo.User");
            DropForeignKey("dbo.Borrowing", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.Tag", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.File", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.Book", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Category", "RootCategory_Id", "dbo.Category");
            DropIndex("dbo.SearchHistory", new[] { "User_Id" });
            DropIndex("dbo.QueueBook", new[] { "Book_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "QueueBook_Id" });
            DropIndex("dbo.Borrowing", new[] { "User_Id" });
            DropIndex("dbo.Borrowing", new[] { "Book_Id" });
            DropIndex("dbo.Tag", new[] { "Book_Id" });
            DropIndex("dbo.File", new[] { "Book_Id" });
            DropIndex("dbo.Category", new[] { "RootCategory_Id" });
            DropIndex("dbo.Book", new[] { "SearchHistory_Id" });
            DropIndex("dbo.Book", new[] { "User_Id" });
            DropIndex("dbo.Book", new[] { "Category_Id" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.SearchHistory");
            DropTable("dbo.QueueBook");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Borrowing");
            DropTable("dbo.Tag");
            DropTable("dbo.File");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
        }
    }
}
