namespace MVCLibrary.Migrations
{
    using MVCLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCLibrary.Models.MVCLIbraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCLibrary.Models.MVCLIbraryContext context)
        {
            // Kategorie
            Category historyczna = new Category() { Name="Historyczna", RootCategoryId=null};
            Category komedia = new Category() { Name = "Komedia", RootCategoryId = null };
            Category horror = new Category() { Name = "Horror", RootCategoryId = null };
            context.Category.AddOrUpdate(c => c.Name,new []{ historyczna,komedia,horror});
            context.SaveChanges();

            //Podkategorie
            Category komediaRomantyczna = new Category() { Name = "Komedia Romantyczna", RootCategoryId = komedia.Id };
            context.Category.AddOrUpdate(c => c.Name, new[] { komediaRomantyczna });

            //Ksiazki


        }
    }
}
