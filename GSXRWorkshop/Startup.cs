using GSXRWorkshop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GSXRWorkshop.Startup))]
namespace GSXRWorkshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            GarageDbContext context = new GarageDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    var user = new ApplicationUser();
            //    user.UserName = "Gregory";
            //    user.Email = "aquiles.craane@gmail.com";

            //    string userPWD = "Laliloe4life123__";

            //    var chkUser = userManager.Create(user, userPWD);

            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = userManager.AddToRole(user.Id, "Admin");
            //    }
            //}
        }

    }
}
