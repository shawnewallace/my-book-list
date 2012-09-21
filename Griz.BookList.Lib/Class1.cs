using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griz.Core;

namespace Griz.BookList.Lib
{

	public class GrizBookListContext : DbContext
	{
		public GrizBookListContext() : base("DefaultConnection")
		{
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Book> Books { get; set; }
	}

	[Table("books")]
	public class Book : EntityBase<int>
	{
		[Column("display_order")]
		public int DisplayOrder { get; set; }

		[Column("user_profile_id")]
		public int UserProfileId { get; set; }

		public UserProfile UserProfile { get; set; }
	}

	[Table("user_profiles")]
	public class UserProfile : EntityBase<int>
	{
		[Column("user_name")]
		public string UserName { get; set; }
	}
}
