using System.Data.Entity;
using Griz.BookList.Lib.Models;

namespace Griz.BookList.Lib.Data
{
	public class GrizBookListContext : DbContext
	{
		public GrizBookListContext() : base("MyBookList")
		{
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Book> Books { get; set; }
	}
}