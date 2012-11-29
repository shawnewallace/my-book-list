namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBeginAndEndReadDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "begin_read", c => c.DateTime());
            AddColumn("dbo.books", "finish_read", c => c.DateTime());
            DropColumn("dbo.books", "is_read");
        }
        
        public override void Down()
        {
            AddColumn("dbo.books", "is_read", c => c.Boolean(nullable: false));
            DropColumn("dbo.books", "finish_read");
            DropColumn("dbo.books", "begin_read");
        }
    }
}
