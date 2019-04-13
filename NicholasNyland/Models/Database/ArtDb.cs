namespace NicholasNyland.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ArtDb : DbContext
    {
        // Your context has been configured to use a 'ArtDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'NicholasNyland.Models.ArtDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ArtDb' 
        // connection string in the application configuration file.
        public ArtDb()
            : base("ArtDatabase")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Art> DbArt { get; set; }
        public virtual DbSet<Exhibit> DbExhibit { get; set; }

        // Add-Migration:
        // Add-Migration -ConfigurationTypeName NicholasNyland.Migrations.ArtMigrations.Configuration "MigrationName"

        // Update-Database:
        // Update-Database -ConfigurationTypeName NicholasNyland.Migrations.ArtMigrations.Configuration
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}