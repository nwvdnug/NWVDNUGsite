using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var nextMeeting = _meetingsService.GetNextMeeting();

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
    }
}
