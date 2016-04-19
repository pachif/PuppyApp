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
                        Location_Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location_Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                .ForeignKey("dbo.UserProfiles", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Leaves_Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Leaves_Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Photo = c.Binary(),
                        Modified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryPoints", "PetId", "dbo.Pets");
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.UserProfiles");
            DropForeignKey("dbo.HistoryPoints", "IllnessId", "dbo.Deseases");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            DropIndex("dbo.HistoryPoints", new[] { "IllnessId" });
            DropIndex("dbo.HistoryPoints", new[] { "PetId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Pets");
            DropTable("dbo.HistoryPoints");
            DropTable("dbo.Deseases");
        }
    }
}
