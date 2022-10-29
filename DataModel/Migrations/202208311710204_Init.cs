namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        DetaledInfo_Description = c.String(),
                        DetaledInfo_BeginDate = c.DateTime(),
                        DetaledInfo_EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Printeds",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ganres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentGanre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ganres", t => t.ParentGanre_Id)
                .Index(t => t.ParentGanre_Id);
            
            CreateTable(
                "dbo.BookDescriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Author_Id = c.Int(),
                        Ganre_Id = c.Int(),
                        Title = c.String(),
                        Fake = c.String(),
                        Genre = c.Int(),
                        DetaledInfo_Description = c.String(),
                        DetaledInfo_BeginDate = c.DateTime(),
                        DetaledInfo_EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.Ganres", t => t.Ganre_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Ganre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookDescriptions", "Ganre_Id", "dbo.Ganres");
            DropForeignKey("dbo.BookDescriptions", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Ganres", "ParentGanre_Id", "dbo.Ganres");
            DropIndex("dbo.BookDescriptions", new[] { "Ganre_Id" });
            DropIndex("dbo.BookDescriptions", new[] { "Author_Id" });
            DropIndex("dbo.Ganres", new[] { "ParentGanre_Id" });
            DropTable("dbo.BookDescriptions");
            DropTable("dbo.Ganres");
            DropTable("dbo.Printeds");
            DropTable("dbo.Authors");
        }
    }
}
