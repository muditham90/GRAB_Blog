namespace GBAB_Blog.Migrations
{
    using GBAB_Blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GBAB_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "GBAB_Blog.Models.ApplicationDbContext";
        }

        protected override void Seed(GBAB_Blog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //Admin role
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            //Moderator role
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //moderator
            if (!context.Users.Any(u => u.Email == "moderator@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@coderfoundry.com",
                    Email = "moderator@coderfoundry.com",
                    FirstName = "CF",
                    LastName = "Moderator",
                    DisplayName = "CF Mod"
                }, "Abc&123!");
            }
            var userId = userManager.FindByEmail("moderator@coderfoundry.com").Id;
            userManager.AddToRole(userId, "Moderator");

            //administrator
            if (!context.Users.Any(u => u.Email == "gabimbo83@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "gabimbo83@gmail.com",
                    Email = "gabimbo83@gmail.com",
                    FirstName = "Gbenga",
                    LastName = "Abimbola",
                    DisplayName = "GBoy"
                }, "Abc&123!");
            }
             userId = userManager.FindByEmail("gabimbo83@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");
        }

    }
}
