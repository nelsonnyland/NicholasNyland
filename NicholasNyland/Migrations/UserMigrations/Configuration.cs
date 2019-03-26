namespace NicholasNyland.Migrations.UserMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NicholasNyland.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NicholasNyland.Models.Database.UserDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\UserMigrations";
        }

        //  This method will be called after migrating to the latest version.
        protected override void Seed(NicholasNyland.Models.Database.UserDb context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // makes an admin role if one doesn't exist
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            // if user doesn't exist, create one and add it to the admin role
            if (!context.Users.Any(u => u.UserName == "nicholasnyland@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);                
                var hash = new PasswordHasher();

                var user = new ApplicationUser
                {
                    UserName = "nicholasnyland@gmail.com",
                    Email = "nicholasnyland@gmail.com",
                    PasswordHash = hash.HashPassword("admin")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
