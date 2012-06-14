using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NWVDNUG.Entities
{
    public class Meeting : IntEntity
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerBioLink { get; set; }
        public string Notes { get; set; }
    }
}