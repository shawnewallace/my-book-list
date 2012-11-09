using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Griz.Core
{
	public class EntityBase<TKey> : IEntity<TKey>, IName, ILogged
	{
		[Key]
		[Column("id")]
		public TKey Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[Column("when_created")]
		public DateTime WhenCreated
		{
			get { return _whenCreated; }
			set { _whenCreated = value; }
		}
		private DateTime _whenCreated = DateTimeHelper.Now;

		[Column("when_modified")]
		public DateTime WhenModified
		{
			get { return _whenModified; }
			set { _whenModified = value; }
		}
		private DateTime _whenModified = DateTimeHelper.Now;

	}
}
