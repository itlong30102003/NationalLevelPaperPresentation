using NationalLevelPaperPresentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NationalLevelPaperPresentation.Areas.Admin.Controllers
{
    public class ParticipantController : Controller
    {
        Model1 db = new Model1();
        // GET: Admin/Participant
        public ActionResult Index()
        {
            var listParticipant = from participant in db.Participants select participant;
            return View(listParticipant);
        }

        public ActionResult Detail(int id)
        {
            var participant = db.Participants.SingleOrDefault(s => s.participant_id == id);
            if (participant == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(participant);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Participant model, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                db.Participants.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Participant participant = db.Participants.SingleOrDefault(n => n.participant_id == id);
            if (participant == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(participant);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Participant model)
        {
            if (ModelState.IsValid)
            {
                db.Participants.AddOrUpdate(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var participant = db.Participants.SingleOrDefault(n => n.participant_id == id);
            if (participant == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(participant);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            Participant participant = db.Participants.SingleOrDefault(n => n.participant_id == id);
            if (participant == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.Participants.Remove(participant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}