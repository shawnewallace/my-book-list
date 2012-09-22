using System.Collections.Generic;
using Griz.BookList.Lib.Models;
using Griz.Core.Data;
using System.Linq;

namespace Griz.BookList.Lib.Data
{
	public interface IBookRepository : IRepository<Book, int>
	{
		List<Book> GetByUserProfileId(int id);
	}

	public class BookRepository : EfRepository<Book, int>, IBookRepository
	{
		public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public List<Book> GetByUserProfileId(int id)
		{
			return Where(b => b.UserProfileId == id).ToList();
		}
	}


	public interface IUserProfileRepository : IRepository<UserProfile, int>
	{
		UserProfile GetByName(string name);
	}

	public class UserProfileRepository : EfRepository<UserProfile, int>, IUserProfileRepository
	{
		public UserProfileRepository(IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}

		public UserProfile GetByName(string name)
		{
			return Where(p => p.UserName == name).FirstOrDefault();
		}
	}
}
