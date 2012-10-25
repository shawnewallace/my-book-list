using Griz.BookList.Lib.Data;
using Griz.BookList.Lib.Models;

namespace Griz.BookList.Lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GrizBookListContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GrizBookListContext context)
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

					//context.Books.AddOrUpdate(
					//	b => b.Name,
					//	new Book{ Name = "War and Peace", UserProfileId = 1 },
					//	new Book { Name = "The Hobbit (Or There and Back Again)", UserProfileId = 1 },
					//	new Book { Name = "The Fellowship of the Ring", UserProfileId = 1 },
					//	new Book { Name = "The Two Towers", UserProfileId = 1 },
					//	new Book { Name = "The Return of the King", UserProfileId = 1 }
					//	);
        }
    }
}
