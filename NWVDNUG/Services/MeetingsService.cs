using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWVDNUG.Data;
using NWVDNUG.Entities;

namespace NWVDNUG.Services
{
    public class MeetingsService
    {
        private NwvdnugDbContext _context;

        public MeetingsService()
        {
            _context = new NwvdnugDbContext();
        }

        #region Crud calls
        public Meeting Add(Meeting newMeeting)
        {
            _context.Meetings.Add(newMeeting);
            _context.SaveChanges();
            return newMeeting;
        }

        public Meeting Update(Meeting meeting)
        {
            _context.Entry(meeting).State = EntityState.Modified;
            _context.SaveChanges();
            return meeting;
        }

        public Meeting Delete(int id)
        {
            Meeting meeting = _context.Meetings.Single(x => x.Id == id);
            meeting.IsArchived = true;
            _context.SaveChanges();
            return meeting;
        }
        #endregion

        public Meeting GetById(int id)
        {
            return GetAllQuery(true).SingleOrDefault(x => x.Id == id);
        }

        public Meeting GetNextMeeting()
        {
            return GetFutureQuery()
                .FirstOrDefault();
        }

        public Meeting[] GetUpcomingMeetings()
        {
            return GetFutureQuery()
                .ToArray();
        }

        public Meeting[] GetPreviousMeetings()
        {
            return GetPastQuery()
                .ToArray();
        }

        #region Private base queries
        private IQueryable<Meeting> GetAllQuery(bool includeInactive)
        {
            var resultQ = _context.Meetings
                    .OrderBy(m => m.StartDateTime);

            if (includeInactive)
                return resultQ;
            else
                return resultQ
                    .Where(m => m.IsArchived == false);
        }

        private IQueryable<Meeting> GetFutureQuery()
        {
            return GetAllQuery(false)
                .Where(m => m.StartDateTime >= DateTime.Now);
        }

        private IQueryable<Meeting> GetPastQuery()
        {
            return GetAllQuery(false)
                .Where(m => m.StartDateTime <= DateTime.Now)
                .OrderByDescending(m => m.StartDateTime);
        }

        #endregion
    }
}