using NationalLevelPaperPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;

namespace NationalLevelPaperPresentation.Controllers
{
    public class HomePageController : Controller
    {
        Model1 db = new Model1();
        private List<Activity> getActivities(int count)
        {
            return db.Activities.OrderByDescending(a=> a.date ).Take(count).ToList();
        }   
        // GET: HomePage
        public ActionResult Index(string searchString,int ?page)
        {
            searchString = searchString ?? "";
            var lstActivity = db.Activities.Where(s => s.name.Contains(searchString)).OrderBy(s => s.activity_id);
            int pageNumber = (page) ?? 1;
            int pageSize = 6;
            ViewBag.TieuDe = "Activity";
            return View(lstActivity.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult FooterPartial()
        {
            return PartialView();
        }
        public ActionResult Menu()
        {
            return PartialView();
        }
        public ActionResult LayoutNavbar()
        {
            return View();
        }
        public ActionResult NavBarDetail()
        {
            return PartialView();
        }
        public ActionResult one()
        {
            return PartialView();
        }
        
        public ActionResult Infor1() 
        {
            return PartialView();
        }
    }
}