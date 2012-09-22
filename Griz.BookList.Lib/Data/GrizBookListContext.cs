using System.Data.Entity;
using Griz.BookList.Lib.Models;

namespace Griz.BookList.Lib.Data
{
	public class GrizBookListContext : DbContext
	{
		public GrizBookListContext() : base("DefaultConnection")
		{
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Book> Books { get; set; }
	}
}