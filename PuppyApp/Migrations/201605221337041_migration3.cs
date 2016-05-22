namespace PuppyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDCard = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserProfiles", "Email", c => c.String());
            AddColumn("dbo.UserProfiles", "Password", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Password");
            DropColumn("dbo.UserProfiles", "Email");
            DropTable("dbo.Owners");
        }
    }
}
