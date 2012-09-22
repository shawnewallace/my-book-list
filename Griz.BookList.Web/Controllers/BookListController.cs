using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Griz.BookList.Lib.Data;

namespace Griz.BookList.Web.Controllers
{
	[Authorize]
	public class BookListController : BaseController
	{
		protected IBookRepository BookRepository { get; set; }

		public BookListController(IBookRepository bookRepo, IUserProfileRepository profileRepo) : base(profileRepo)
		{
			BookRepository = bookRepo;
		}

		//
		// GET: /BookList/
		public ActionResult Index()
		{
			var id = CurrentUser.Id;
			var model = BookRepository.GetByUserProfileId(id);

			return View(model);
		}

	}
}
