namespace Attitude_Aviation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Planes");
        }
    }

    public partial class AddRequestsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maintenance",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Plane_Name = c.String(),
                    Problem = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Maintenance");
        }
    }
}
