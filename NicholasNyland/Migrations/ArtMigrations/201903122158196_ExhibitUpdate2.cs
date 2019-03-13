namespace NicholasNyland.Migrations.ArtMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExhibitUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arts", "Exhibit_Name", "dbo.Exhibits");
            DropIndex("dbo.Arts", new[] { "Exhibit_Name" });
            DropColumn("dbo.Arts", "Exhibit_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Arts", "Exhibit_Name", c => c.String(maxLength: 128));
            CreateIndex("dbo.Arts", "Exhibit_Name");
            AddForeignKey("dbo.Arts", "Exhibit_Name", "dbo.Exhibits", "Name");
        }
    }
}
