namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActiveAndIsAdminToProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.user_profiles", "is_admin", c => c.Boolean(nullable: false));
            AddColumn("dbo.user_profiles", "is_active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.user_profiles", "is_active");
            DropColumn("dbo.user_profiles", "is_admin");
        }
    }
}
