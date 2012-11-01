using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griz.Core;

namespace Griz.BookList.Lib.Extensions
{
	public class ListShifter<T, TKey> where T : IId<TKey>, IShiftable
	{
		public List<T> ListToShift { get; set; }
		public List<T> Shift(TKey idToShift, int zeroIndexedNewPosition)
		{
			var thingToMove = ListToShift.FirstOrDefault(t => t.Id.Equals(idToShift));
			var shiftedList = ListToShift
												.Where(l => !l.Id.Equals(idToShift))
												.OrderBy(l => l.DisplayOrder)
												.ToList();

			if (zeroIndexedNewPosition < shiftedList.Count)
				shiftedList.Insert(zeroIndexedNewPosition, thingToMove);
			else
				shiftedList.Add(thingToMove);
			
			//index list to 0
			var index = 0;
			foreach (var thing in shiftedList) thing.DisplayOrder = index++;

			return shiftedList;
		}
	}
}
