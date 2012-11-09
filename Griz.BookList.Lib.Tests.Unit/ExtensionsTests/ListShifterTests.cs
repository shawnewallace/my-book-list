using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Griz.BookList.Lib.Extensions;
using NUnit.Framework;
using Griz.Core;

namespace Griz.Core.Tests.Unit.Griz.BookList.Lib.Tests.ExtensionsTests
{
	public class ShiftableEntity :  IId<int>, IShiftable
	{
		public int Id { get; set; }
		public int DisplayOrder { get; set; }
	}

	[TestFixture]
	public class list_shifter_base
	{
		protected List<IShiftable> _listToShift;
		protected ListShifter<ShiftableEntity, int> _shifter;

		[SetUp]
		public void SetUp()
		{
			_listToShift = new List<IShiftableEntity>();
			_shifter = new ListShifter();
		}
	}

	[TestFixture]
	public class shifted_thing_should_have_correct_index : list_shifter_base
	{
		[Test]
		public void one_thing_index_zero()
		{
			_listToShift.Add(new ShiftableEntity { Id = 1, DisplayOrder = 7 });
			_shifter.ListToShift = _listToShift;

			var newList = _shifter.Shift(1, 10);
			Assert.That(_listToShift.Count == 1);
			Assert.AreEqual(0, newList.First().DisplayOrder);
		}

		[Test]
		public void moves_first_thing_to_second_spot()
		{
			for (var i = 0; i < 3; i++)
			{
				_listToShift.Add(new ShiftableEntity { Id = i, DisplayOrder = i });
			}

			_shifter.ListToShift = _listToShift;
			var result = _shifter.Shift(0, 1);

			var shiftedThing = result.First(f => f.Id == 0);

			Assert.AreEqual(1, shiftedThing.DisplayOrder);
		}

		[Test]
		public void moves_things_around_spot()
		{
			for (var i = 0; i < 5; i++)
			{
				_listToShift.Add(new ShiftableEntity { Id = i, DisplayOrder = i });
			}

			_shifter.ListToShift = _listToShift;
			var result = _shifter.Shift(2, 4);

			Assert.AreEqual(0, result.First(f => f.Id == 0).DisplayOrder);
			Assert.AreEqual(1, result.First(f => f.Id == 1).DisplayOrder);
			Assert.AreEqual(2, result.First(f => f.Id == 3).DisplayOrder);
			Assert.AreEqual(3, result.First(f => f.Id == 4).DisplayOrder);
			Assert.AreEqual(4, result.First(f => f.Id == 2).DisplayOrder);
		}

		[Test]
		public void moves_things_around_2()
		{
			for (var i = 0; i < 5; i++)
			{
				_listToShift.Add(new ShiftableEntity { Id = i, DisplayOrder = i });
			}

			_shifter.ListToShift = _listToShift;
			var result = _shifter.Shift(4, 1);

			Assert.AreEqual(0, result.First(f => f.Id == 0).DisplayOrder);
			Assert.AreEqual(1, result.First(f => f.Id == 4).DisplayOrder);
			Assert.AreEqual(2, result.First(f => f.Id == 1).DisplayOrder);
			Assert.AreEqual(3, result.First(f => f.Id == 2).DisplayOrder);
			Assert.AreEqual(4, result.First(f => f.Id == 3).DisplayOrder);
		}

		[Test]
		public void does_a_swap()
		{
			for (var i = 0; i < 2; i++)
			{
				_listToShift.Add(new ShiftableEntity { Id = i, DisplayOrder = i });
			}

			_shifter.ListToShift = _listToShift;
			var result = _shifter.Shift(0, 1);

			var shiftedThing = result.First(f => f.Id == 0);

			Assert.AreEqual(1, shiftedThing.DisplayOrder);
		}

		[Test]
		public void does_a_swap_the_other_way()
		{
			for (var i = 0; i < 2; i++)
			{
				_listToShift.Add(new ShiftableEntity { Id = i, DisplayOrder = i });
			}

			_shifter.ListToShift = _listToShift;
			var result = _shifter.Shift(1, 0);

			var shiftedThing = result.First(f => f.Id == 1);

			Assert.AreEqual(0, shiftedThing.DisplayOrder);
		}

		[Test]
		public void re_indexes_list_to_zero()
		{
			for (var i = 0; i < 10; i++)
			{
				_listToShift.Add(new ShiftableEntity { Id = i, DisplayOrder = i * 7 });
			}

			_shifter.ListToShift = _listToShift;
			_shifter.Shift(0, 0);

			foreach (var thing in _listToShift)
			{
				Assert.AreEqual(thing.Id, thing.DisplayOrder);
			}
		}
	}
}
