using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Griz.BookList.Lib.Data;
using Griz.BookList.Lib.Models;

namespace Griz.BookList.Web.Controllers
{
    public class BaseController : Controller
    {
			protected IUserProfileRepository UserProfileRepository { get; set; }

			public BaseController(IUserProfileRepository repo)
			{
				UserProfileRepository = repo;
			}

	    public UserProfile CurrentUser
	    {
		    get
		    {
			    if (Session["CURRENT_USER"] == null)
			    {
				    Session["CURRENT_USER"] = UserProfileRepository.GetByName(User.Identity.Name);
			    }

			    return (UserProfile) Session["CURRENT_USER"];
		    }
				set { Session["CURRENT_USER"] = value; }
	    }
    }
}
