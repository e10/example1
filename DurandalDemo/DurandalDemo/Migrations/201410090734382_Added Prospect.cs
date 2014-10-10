namespace DurandalDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProspect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prospect",
                c => new
                    {
                        ProspectID = c.Guid(nullable: false),
                        ProspectName = c.String(),
                        ProspectType = c.Int(nullable: false),
                        Closed = c.Boolean(nullable: false),
                        AdditionalInfo = c.String(),
                    })
                .PrimaryKey(t => t.ProspectID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prospect");
        }
    }
}
