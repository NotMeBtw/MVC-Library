namespace MVCLibrary.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class MVCLIbraryContext : DbContext
    {
        // Your context has been configured to use a 'MVCLIbraryContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVCLibrary.Models.MVCLIbraryContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MVCLIbraryContext' 
        // connection string in the application configuration file.
        public MVCLIbraryContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public static MVCLIbraryContext Create()
        {
            return new MVCLIbraryContext();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Lend> Borrows { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<QueueBook> Queues { get; set; }
        public DbSet<SearchHistory> Search { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}