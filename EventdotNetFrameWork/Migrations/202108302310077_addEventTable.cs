namespace EventdotNetFrameWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Country = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Img = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.EventId);
            
          
            
        }
        
        public override void Down()
        {
          
            DropTable("dbo.Events");
        }
    }
}
