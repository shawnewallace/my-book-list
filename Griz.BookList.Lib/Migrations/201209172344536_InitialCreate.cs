namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.user_profile",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_name = c.String(),
                        name = c.String(),
                        when_created = c.DateTime(nullable: false),
                        when_modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_profile_id = c.Int(nullable: false),
                        name = c.String(),
                        when_created = c.DateTime(nullable: false),
                        when_modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user_profile", t => t.user_profile_id, cascadeDelete: true)
                .Index(t => t.user_profile_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.books", new[] { "user_profile_id" });
            DropForeignKey("dbo.books", "user_profile_id", "dbo.user_profile");
            DropTable("dbo.books");
            DropTable("dbo.user_profile");
        }
    }
}
