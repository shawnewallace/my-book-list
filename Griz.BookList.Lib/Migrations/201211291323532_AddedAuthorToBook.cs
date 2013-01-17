namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthorToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "author");
        }
    }
}
