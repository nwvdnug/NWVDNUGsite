using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWVDNUG.Entities;
using NWVDNUG.Services;
using NWVDNUG.ViewModels;

namespace NWVDNUG.Controllers
{
	public class HomeController : Controller
	{
		private MeetingsService _meetingsService = new MeetingsService();

		public ActionResult Index()
		{
			var model = BuildHomePageModel();
			return View(model);
		}

		private HomePageViewModel BuildHomePageModel()
		{
			var nextMeeting = _meetingsService.GetNextMeeting() ?? new Meeting
				{
					IsArchived = false,
					Title = "No Meeting Info Found",
					SpeakerName = "",
					Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
				};

			return new HomePageViewModel
					   {
						   NextMeetingInfo = nextMeeting
					   };
		}

		public ActionResult About()
		{
			return View();
		}

		public ViewResult Network()
		{
			return View();
		}

		public ViewResult Sponsors()
		{
			return View();
		}

		public ViewResult Privacy()
		{
			return View();
		}

		//public ActionResult Full()
		//{
			//return File("Views/Home/Full.rss", "text/xml");
			//return View("Full.rss");
		//}
	}
}
