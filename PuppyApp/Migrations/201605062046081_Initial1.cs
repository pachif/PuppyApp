namespace PuppyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HistoryPoints", "Location_Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.HistoryPoints", "Location_Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.UserProfiles", "Leaves_Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.UserProfiles", "Leaves_Longitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Leaves_Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.UserProfiles", "Leaves_Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoryPoints", "Location_Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoryPoints", "Location_Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
