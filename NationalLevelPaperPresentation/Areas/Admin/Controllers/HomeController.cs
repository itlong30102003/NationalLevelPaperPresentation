using NationalLevelPaperPresentation.Areas.Navigation;
using NationalLevelPaperPresentation.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace NationalLevelPaperPresentation.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return RedirectToAction("Login");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string UserName = f["UserName"];
            string Password = f["Password"];
            var admin = db.Admins.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            if (admin != null)
            {
                Session["Admin"] = admin;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Sai UserName va Password";
            }
            return View();
        }
        public ActionResult MenuPartial()
        {
            var path = Server.MapPath("~/Areas/Navigation/Navigation.json");
            var content = System.IO.File.ReadAllText(path);
            var menu = JsonConvert.DeserializeObject<NavigationMenu>(content);
            return PartialView(menu);
        }
        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return RedirectToAction("Index");
        }
        
    }
}