using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Griz.BookList.Web.Controllers
{
	[Authorize]
	public class BookListController : Controller
	{
		//
		// GET: /BookList/
		public ActionResult Index()
		{
			var user = User.Identity.Name;

			return View();
		}

	}
}
