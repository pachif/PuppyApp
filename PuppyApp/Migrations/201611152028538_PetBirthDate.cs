namespace PuppyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "BirthDate");
        }
    }
}