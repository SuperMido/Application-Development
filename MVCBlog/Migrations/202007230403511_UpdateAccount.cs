namespace MVCBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Body = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.Posts");
        }
    }
}
