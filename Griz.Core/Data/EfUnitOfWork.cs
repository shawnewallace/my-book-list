
using System.Data.Entity;

namespace Griz.Core.Data
{
	public class EfUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EfUnitOfWork() { }
		public EfUnitOfWork(DbContext context)
		{
			Context = context;
		}

		public void Commit()
		{
			Context.SaveChanges();
		}
		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}
		public void Dispose()
		{
			Context.Dispose();
		}
	}
}
