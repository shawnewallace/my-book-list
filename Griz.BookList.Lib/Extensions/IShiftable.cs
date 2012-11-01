using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griz.BookList.Lib.Extensions
{
	public interface IShiftable
	{
		int DisplayOrder { get; set; }
	}
}
