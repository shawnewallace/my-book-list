using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griz.BookList.Lib;
using Griz.BookList.Lib.Data;
using Griz.BookList.Lib.Models;
using NUnit.Framework;

namespace Griz.BookList.Tests.Integration
{
	[TestFixture]
	public class Class1
	{
		[SetUp]
		public void SetUp()
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<GrizBookListContext>());
		}

		[Test]
		public void smoke_test()
		{
			using(var db = new GrizBookListContext())
			{
				var user = new UserProfile
					           {
						           Name = "name",
						           UserName = "user_name",
					           };
				db.UserProfiles.Add(user);

				db.Books.Add(new Book { DisplayOrder = 0, Name = "BOOK 0", UserProfile = user});
				db.Books.Add(new Book { DisplayOrder = 1, Name = "BOOK 1", UserProfile = user });
				db.Books.Add(new Book { DisplayOrder = 2, Name = "BOOK 2", UserProfile = user });

				db.SaveChanges();

				Assert.That(db.Books.Select(b => b).ToList().Count() == 3);
			}
		}
	}
}
