namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsReadFlagToBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "is_read", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "is_read");
        }
    }
}
