using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Griz.Core.Data
{
	public class EfRepository<T, TKey> : IRepository<T, TKey>
		where T : class, IEntity<TKey>
	{
		public IUnitOfWork UnitOfWork { get; set; }

		private DbSet<T> _objectset;
		private DbSet<T> ObjectSet
		{
			get { return _objectset ?? (_objectset = UnitOfWork.Context.Set<T>()); }
		}

		public EfRepository() { }
		public EfRepository(IUnitOfWork unitOfWork) { UnitOfWork = unitOfWork; }

		public IQueryable<T> All(params Expression<Func<T, object>>[] includes)
		{
			var query = ObjectSet.AsQueryable();

			if (includes != null)
				query = includes.Aggregate(query, (current, include) => current.Include(include));

			return query;
		}

		public IQueryable<T> Where(Func<T, bool> expression, params Expression<Func<T, object>>[] includes)
		{
			var query = ObjectSet.Where(expression).AsQueryable();

			if (includes != null)
				query = includes.Aggregate(query, (current, include) => current.Include(include));

			return query;
		}

		public T GetById(TKey id, params Expression<Func<T, object>>[] includes)
		{
			var query = Where(e => e.Id.Equals(id));

			if (includes != null)
				query = includes.Aggregate(query, (current, include) => current.Include(include));

			return query.FirstOrDefault();
		}

		public T Add(T entity)
		{
			var x = ObjectSet.Add(entity);
			return x;
		}

		public void Delete(T entity)
		{
			ObjectSet.Remove(entity);
		}

		public void DeleteById(TKey id)
		{
			var entityToDelete = GetById(id);
			Delete(entityToDelete);
		}
	}
}
