using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TopGym_System.Models;

[assembly: OwinStartupAttribute(typeof(TopGym_System.Startup))]
namespace TopGym_System
{

    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }


        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Ahmed";
                user.Email = "AhmedSalem1041998@gmail.com";
                var Check = usermanager.Create(user, "ahmed1041998");
                if (Check.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Admins");
                }

            }
        }
    }
}
