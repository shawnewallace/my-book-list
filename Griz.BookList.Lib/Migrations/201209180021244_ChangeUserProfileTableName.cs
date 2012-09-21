namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserProfileTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.user_profile", newName: "user_profiles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.user_profiles", newName: "user_profile");
        }
    }
}
