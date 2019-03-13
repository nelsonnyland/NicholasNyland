namespace NicholasNyland.Migrations.ArtMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExhbitUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exhibits", "ArtKeys", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exhibits", "ArtKeys");
        }
    }
}
