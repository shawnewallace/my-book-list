using System.Linq;
using System.Web.Mvc;
using Griz.BookList.Lib.Data;

namespace Griz.BookList.Web.Controllers
{
	[Authorize]
	public class ProfilesController : BaseController
	{
		public ProfilesController(IUserProfileRepository profileRepo)
			: base(profileRepo)
		{
		}

		public ActionResult Index()
		{
			//if (!CurrentUser.IsAdmin) return RedirectToAction("Index", "Book");

			var model = UserProfileRepository.All().ToList();
			return View(model);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			var profileToEdit = UserProfileRepository.GetById(id);

			return View(profileToEdit);
		}
	}
}
