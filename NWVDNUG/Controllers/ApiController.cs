using System.Linq;
using System.Web.Mvc;
using NWVDNUG.Entities;
using NWVDNUG.Services;

namespace NWVDNUG.Controllers
{
    public class ApiController : Controller
    {
        private readonly MeetingsService _meetingsService = new MeetingsService();
        private readonly DtoFactory _dtoFactory = new DtoFactory();

        public JsonResult NextMeeting()
        {
            Meeting meeting = _meetingsService.GetNextMeeting();

            var meetingDto = _dtoFactory.CreateMeetingDto(meeting);

            return Json(meetingDto, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpcomingMeetings()
        {
            Meeting[] upcomingMeetings = _meetingsService.GetUpcomingMeetings();

            var meetingDtos = upcomingMeetings.Select(m=>_dtoFactory.CreateMeetingDto(m));

            return Json(meetingDtos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PastMeetings()
        {
            Meeting[] upcomingMeetings = _meetingsService.GetPreviousMeetings();

            var meetingDtos = upcomingMeetings.Select(m=>_dtoFactory.CreateMeetingDto(m));

            return Json(meetingDtos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllMeetings()
        {
            Meeting[] upcomingMeetings = _meetingsService.GetActiveMeetings();

            var meetingDtos = upcomingMeetings.Select(m=>_dtoFactory.CreateMeetingDto(m));

            return Json(meetingDtos, JsonRequestBehavior.AllowGet);
        }
    }
}
