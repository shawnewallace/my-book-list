namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Griz.BookList.Lib.GrizBookListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Griz.BookList.Lib.GrizBookListContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
					context.UserProfiles.AddOrUpdate(
						p => p.UserName,
						new UserProfile { UserName = "andrew_peters" },
						new UserProfile { UserName = "brice_lambson" },
						new UserProfile { UserName = "rowan_miller" }
					);
					
        }
    }
}
