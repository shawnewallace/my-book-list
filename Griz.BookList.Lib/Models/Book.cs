using System;
using System.ComponentModel.DataAnnotations.Schema;
using Griz.Core;
using Griz.BookList.Lib.Extensions;

namespace Griz.BookList.Lib.Models
{
	[Table("books")]
	public class Book : EntityBase<int>, IShiftable<int>
	{
		[Column("display_order")]
		public int DisplayOrder { get; set; }

		[Column("user_profile_id")]
		public int UserProfileId { get; set; }

		[Column("begin_read")]
		public DateTime? WhenBeginRead { get; set; }

		[Column("finish_read")]
		public DateTime? WhenFinishRead { get; set; }

		public UserProfile UserProfile { get; set; }

		[NotMapped]
		public bool IsRead { get { return WhenFinishRead.HasValue; } }
	}
}