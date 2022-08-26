namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Authors",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Surname = c.String(nullable: false),
            //            About = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //AddColumn("dbo.BookDescriptions", "Author_Id", c => c.Int());
            //CreateIndex("dbo.BookDescriptions", "Author_Id");
            //AddForeignKey("dbo.BookDescriptions", "Author_Id", "dbo.Authors", "Id");
            //DropColumn("dbo.BookDescriptions", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookDescriptions", "Author", c => c.String());
            DropForeignKey("dbo.BookDescriptions", "Author_Id", "dbo.Authors");
            DropIndex("dbo.BookDescriptions", new[] { "Author_Id" });
            DropColumn("dbo.BookDescriptions", "Author_Id");
            DropTable("dbo.Authors");
        }
    }
}
