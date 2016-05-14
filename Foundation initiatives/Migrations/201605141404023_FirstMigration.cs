namespace Foundation_initiatives.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Initiatives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Director_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Director_Id)
                .Index(t => t.Director_Id);
            
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DeadLine = c.DateTime(nullable: false),
                        InitiativeId = c.Int(nullable: false),
                        StepDirector_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Initiatives", t => t.InitiativeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.StepDirector_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.InitiativeId)
                .Index(t => t.StepDirector_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "PointsCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Photo", c => c.String());
            AddColumn("dbo.AspNetUsers", "About", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Step_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Step_Id");
            AddForeignKey("dbo.AspNetUsers", "Step_Id", "dbo.Steps", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Initiatives", "Director_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Steps", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Step_Id", "dbo.Steps");
            DropForeignKey("dbo.Steps", "StepDirector_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Steps", "InitiativeId", "dbo.Initiatives");
            DropIndex("dbo.Steps", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Steps", new[] { "StepDirector_Id" });
            DropIndex("dbo.Steps", new[] { "InitiativeId" });
            DropIndex("dbo.AspNetUsers", new[] { "Step_Id" });
            DropIndex("dbo.Initiatives", new[] { "Director_Id" });
            DropColumn("dbo.AspNetUsers", "Step_Id");
            DropColumn("dbo.AspNetUsers", "IsFree");
            DropColumn("dbo.AspNetUsers", "About");
            DropColumn("dbo.AspNetUsers", "Photo");
            DropColumn("dbo.AspNetUsers", "PointsCount");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Steps");
            DropTable("dbo.Initiatives");
        }
    }
}
