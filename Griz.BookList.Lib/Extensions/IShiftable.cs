using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griz.Core;

namespace Griz.BookList.Lib.Extensions
{
	public interface IShiftable<TKey> : IId<TKey>
	{
		int DisplayOrder { get; set; }
	}
}
