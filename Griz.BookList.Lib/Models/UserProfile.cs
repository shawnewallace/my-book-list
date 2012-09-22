using System.ComponentModel.DataAnnotations.Schema;
using Griz.Core;

namespace Griz.BookList.Lib.Models
{
	[Table("user_profiles")]
	public class UserProfile : EntityBase<int>
	{
		[Column("user_name")]
		public string UserName { get; set; }
	}
}
