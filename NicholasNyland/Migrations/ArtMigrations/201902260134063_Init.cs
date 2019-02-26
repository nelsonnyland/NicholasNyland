namespace NicholasNyland.Migrations.ArtMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arts",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        Path = c.String(),
                        Exhibit_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.Exhibits", t => t.Exhibit_Name)
                .Index(t => t.Exhibit_Name);
            
            CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arts", "Exhibit_Name", "dbo.Exhibits");
            DropIndex("dbo.Arts", new[] { "Exhibit_Name" });
            DropTable("dbo.Exhibits");
            DropTable("dbo.Arts");
        }
    }
}
