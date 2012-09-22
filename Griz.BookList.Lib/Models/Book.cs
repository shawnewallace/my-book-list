using System.ComponentModel.DataAnnotations.Schema;
using Griz.Core;

namespace Griz.BookList.Lib.Models
{
	[Table("books")]
	public class Book : EntityBase<int>
	{
		[Column("display_order")]
		public int DisplayOrder { get; set; }

		[Column("user_profile_id")]
		public int UserProfileId { get; set; }

		public UserProfile UserProfile { get; set; }
	}
}