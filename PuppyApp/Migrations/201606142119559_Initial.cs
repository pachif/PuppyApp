namespace PuppyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        When = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Location_Latitude = c.Double(nullable: false),
                        Location_Longitude = c.Double(nullable: false),
                        PetId = c.Int(nullable: false),
                        IllnessId = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deseases", t => t.IllnessId, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.IllnessId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Specie = c.String(nullable: false),
                        Photo = c.Binary(),
                        OwnerId = c.Int(nullable: false),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDCard = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.Binary(),
                        Leaves_Latitude = c.Double(nullable: false),
                        Leaves_Longitude = c.Double(nullable: false),
                        Photo = c.Binary(),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryPoints", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.HistoryPoints", "IllnessId", "dbo.Deseases");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            DropIndex("dbo.HistoryPoints", new[] { "IllnessId" });
            DropIndex("dbo.HistoryPoints", new[] { "PetId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Owners");
            DropTable("dbo.Pets");
            DropTable("dbo.HistoryPoints");
            DropTable("dbo.Deseases");
        }
    }
}
