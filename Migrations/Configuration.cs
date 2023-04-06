namespace TopGym_System.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TopGym_System.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TopGym_System.Models.ApplicationDbContext>
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TopGym_System.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
            //UserManager<ApplicationUser> manger = new UserManager<ApplicationUser>(store);
            //if (!context.Users.Any(u => u.UserName == ""))
            //{
            //    ApplicationUser user = new ApplicationUser();
            //    {
            //        user.UserName = "Ahmed";
            //        user.Email = "Ahmedsalem1041998@gmail.com";
            //    };
            //    manger.Create(user, "1041998#");

            //}
        }
    }
}
