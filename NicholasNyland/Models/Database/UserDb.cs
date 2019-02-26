using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NicholasNyland.Models.Database
{
    public class UserDb : IdentityDbContext<ApplicationUser>
    {
        public UserDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UserDb Create()
        {
            return new UserDb();
        }

        // Add-Migration:
        // Add-Migration -ConfigurationTypeName NicholasNyland.Migrations.UserMigrations.Configuration "MigrationName"

        // Update-Database:
        // Update-Database -ConfigurationTypeName NicholasNyland.Migrations.UserMigrations.Configuration
    }
}