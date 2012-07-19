using System.Globalization;
using NWVDNUG.Entities;
using NWVDNUG.Models;

namespace NWVDNUG.Controllers
{
    public class DtoFactory
    {
        public MeetingDto CreateMeetingDto(Meeting meeting)
        {
            var resultDto = new MeetingDto
                                {
                                    Id = meeting.Id,
                                    Title = meeting.Title,
                                    Notes = meeting.Notes,
                                    Location = meeting.Location,
                                    SpeakerName = meeting.SpeakerName,
                                    SpeakerBioLink = meeting.SpeakerBioLink,
                                    MeetingStartTime = meeting.StartDateTime.ToString(CultureInfo.CurrentCulture),
                                    MeetingEndTime = meeting.EndDateTime.ToString(CultureInfo.CurrentCulture)
                                };
            
            return resultDto;
        }
    }
}