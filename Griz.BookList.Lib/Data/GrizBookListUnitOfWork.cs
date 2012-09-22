using System.Data.Entity;
using Griz.Core.Data;

namespace Griz.BookList.Lib.Data
{
	public class GrizBookListUnitOfWork : EfUnitOfWork
	{
		public GrizBookListUnitOfWork()
		{
			Context = new GrizBookListContext();
		}

		public GrizBookListUnitOfWork(DbContext context)
		{
			Context = context;
		} 
	}
}