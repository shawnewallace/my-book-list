using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Griz.BookList.Lib.Data;
using Griz.Core;
using Griz.BookList.Lib.Extensions;

namespace Griz.BookList.Web.Controllers
{
	[Authorize]
	public class BookController : BaseController
	{
		protected IBookRepository BookRepository { get; set; }

		public BookController(IBookRepository bookRepo, IUserProfileRepository profileRepo) : base(profileRepo)
		{
			BookRepository = bookRepo;
		}

		//
		// GET: /Book/
		public ActionResult Index()
		{
			var id = CurrentUser.Id;
			var model = BookRepository.GetByUserProfileId(id);

			return View(model);
		}

		//
		//POST: /Book/Add/{name}
		public ActionResult Add(string name)
		{
			var profileId = CurrentUser.Id;
			var books = BookRepository.GetByUserProfileId(profileId);

			var maxPosition = books.Count() > 0 ? books.Max(b => b.DisplayOrder) : 0;
			
			BookRepository.Add(
				new Lib.Models.Book { 
					UserProfileId = profileId,
					Name = name,
					DisplayOrder = maxPosition + 1,
					WhenCreated = DateTimeHelper.Now,
					WhenModified = DateTimeHelper.Now
			});
			
			BookRepository.UnitOfWork.Commit();
			
			return RedirectToAction("Index");
		}

		//
		//POST: /Book/{id}/{pos}
		public JsonResult Update(int id, int pos)
		{
			var profileId = CurrentUser.Id;
			var books = BookRepository.GetByUserProfileId(profileId);
			books = MoveBookInList(id, pos, books);

			BookRepository.UnitOfWork.Commit();

			return Json(true);
		}

		//
		//DELETE: /Book/Delete/{id}
		public JsonResult Delete(int id)
		{
			var profileId = CurrentUser.Id;

			if (!BookOwnedByProfile(id, profileId)) return Json(false);

			BookRepository.DeleteById(id);

			BookRepository.UnitOfWork.Commit();

			return Json(true);
		}

		public JsonResult ToggleRead(int id)
		{
			var profileId = CurrentUser.Id;

			if (!BookOwnedByProfile(id, profileId)) return Json(false);

			var book = BookRepository.GetById(id);

			if (book.IsNullOrEmpty()) return Json(false);

			if (!book.WhenBeginRead.HasValue) book.WhenBeginRead = DateTimeHelper.Now;
			else if (!book.WhenFinishRead.HasValue) book.WhenFinishRead = DateTimeHelper.Now;

			BookRepository.UnitOfWork.Commit();

			return Json(true);
		}

		private List<Lib.Models.Book> MoveBookInList(int id
			, int newPosition
			, List<Lib.Models.Book> oldList)
		{
			var shifter = new ListShifter<Lib.Models.Book, int>
			{
				ListToShift = oldList
			};
			
			return shifter.Shift(id, newPosition);
		}

		private bool BookOwnedByProfile(int bookId, int profileId)
		{
			var books = BookRepository.GetByUserProfileId(profileId);
			return books.Exists(m => m.Id == bookId);
		}
	}
}
