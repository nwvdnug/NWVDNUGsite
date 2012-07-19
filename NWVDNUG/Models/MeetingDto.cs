using System;
using System.Runtime.Serialization;

namespace NWVDNUG.Models
{
    [DataContract]
    public class MeetingDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string SpeakerName { get; set; }

        [DataMember]
        public string SpeakerBioLink { get; set; }

        [DataMember]
        public String MeetingStartTime { get; set; }

        [DataMember]
        public String MeetingEndTime { get; set; }
    }
}