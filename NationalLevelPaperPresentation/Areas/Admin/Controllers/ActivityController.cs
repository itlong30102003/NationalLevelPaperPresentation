using NationalLevelPaperPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity.Migrations;
using System.Drawing;
using NationalLevelPaperPresentation;


namespace NationalLevelPaperPresentation.Areas.Admin.Controllers
{
    public class ActivityController : Controller
    {
        Model1 db = new Model1();

        public ActionResult Index()
        {
            var listActivity = from activity in db.Activities select activity;
            return View(listActivity);
        }


        public ActionResult Detail(int id)
        {
            var activity = db.Activities.FirstOrDefault(s => s.activity_id == id);
            return View(activity);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]                                  
        public ActionResult Create(Activity model, FormCollection f, HttpPostedFileBase fFileUpload)
        {
            if (ModelState.IsValid)
            {
                if (fFileUpload != null)
                {
                    Image img = Image.FromStream(fFileUpload.InputStream, true, true);
                    model.Image = Utility.ConvertImageToBase64(img);
                }
                db.Activities.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public static string ConverImageToBase64(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = "data:image/jpeg;base64," + Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Activity ac = db.Activities.SingleOrDefault(n => n.activity_id == id);
            if (ac == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(ac);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Activity ac)
        {
            if (ModelState.IsValid)
            {
                db.Activities.AddOrUpdate(ac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            Activity ac = db.Activities.SingleOrDefault(n => n.activity_id == id);
            if (ac == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ac);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection f)
        {
            var activity = db.Activities.SingleOrDefault(n => n.activity_id == id);
            if (activity == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.Activities.Remove(activity);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}