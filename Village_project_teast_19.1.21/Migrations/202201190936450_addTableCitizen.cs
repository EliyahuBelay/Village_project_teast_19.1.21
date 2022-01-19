namespace Village_project_teast_19._1._21.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableCitizen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citizens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FathrName = c.String(),
                        Gender = c.String(),
                        IsBornInTheVillage = c.Boolean(nullable: false),
                        DateBith = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Citizens");
        }
    }
}
