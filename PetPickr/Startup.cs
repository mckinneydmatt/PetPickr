using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PetPickr.Data;

[assembly: OwinStartupAttribute(typeof(PetPickr.Startup))]
namespace PetPickr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }
        // In this method we will create default User roles and Admin user for login    
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Here we create a Admin super user who will maintain the website                   

            //var user = new ApplicationUser();
            //user.UserName = "admin";
            //user.Email = "admin@admin.com";

            //string userPWD = "ADMIN123";

            //var chkUser = UserManager.Create(user, userPWD);

            ////Add default User to Role Admin    
            //if (chkUser.Succeeded)
            //{
            //    var result1 = UserManager.AddToRole(user.Id, "Admin");

            //}


                // Creating Admin role     
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            // Creating Customer role     
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
            // Creating Shelter admin role     
            if (!roleManager.RoleExists("Shelter"))
            {
                var role = new IdentityRole();
                role.Name = "Shelter";
                roleManager.Create(role);
            }
        }
    }
}
