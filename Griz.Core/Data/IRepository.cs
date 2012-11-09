using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Griz.Core.Data
{
	public interface IRepository<T, TKey> where T : IEntity<TKey>
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All(params Expression<Func<T, object>>[] includes);
		IQueryable<T> Where(Func<T, bool> expression, params Expression<Func<T, object>>[] includes);
		T GetById(TKey id, params Expression<Func<T, object>>[] includes);
		T Add(T entity);
		void Delete(T entity);
		void DeleteById(TKey id);
	}
}
