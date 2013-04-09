using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWVDNUG.Data;
using NWVDNUG.Entities;
using NWVDNUG;
using NWVDNUG.Services;

namespace NWVDNUG.Controllers
{   
    public class MeetingsController : Controller
    {
        private MeetingsService _meetingsService = new MeetingsService();

        //
        // GET: /Meetings/

        public ViewResult Index()
        {
            ViewBag.NavActive = "MeetingUpcoming";
            return View(_meetingsService.GetUpcomingMeetings());
        }

        //
        // GET: /Meetings/Details/5

        public ViewResult Details(int id)
        {
            return View(_meetingsService.GetById(id));
        }

        //
        // GET: /Meetings/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Meetings/Create

        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _meetingsService.Add(meeting);
                return RedirectToAction("Index");  
            }

            return View(meeting);
        }
        
        //
        // GET: /Meetings/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(_meetingsService.GetById(id));
        }

        //
        // POST: /Meetings/Edit/5

        [HttpPost]
        public ActionResult Edit(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _meetingsService.Update(meeting);
                return RedirectToAction("Index");
            }
            return View(meeting);
        }

        //
        // GET: /Meetings/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(_meetingsService.GetById(id));
        }

        //
        // POST: /Meetings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _meetingsService.Delete(id);
            return RedirectToAction("Index");
        }

        public ViewResult Next()
        {
            var meeting = _meetingsService.GetNextMeeting() ?? new Meeting
            {
                IsArchived = false,
                Title = "No Meeting Info Found",
                SpeakerName = "",
                Location = "Foothills Recreation Center, 5600 W Union Hills Ave, Glendale, AZ, 85308",
            };

            ViewBag.NavActive = "MeetingNext";
            return View("Details", meeting);

        }
    }
}