namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisplayOrderToBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "display_order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.books", "display_order");
        }
    }
}
