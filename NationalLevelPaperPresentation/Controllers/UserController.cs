using NationalLevelPaperPresentation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using WebGrease;

namespace NationalLevelPaperPresentation.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User Model)
        {
            if (ModelState.IsValid)
            {
                var kh = db.Users.FirstOrDefault(k => k.username == Model.username);
                if (kh != null)
                {
                    ModelState.AddModelError("UserName", "This account has already existed");
                    return View(Model);
                }

                db.Users.Add(Model);
                db.SaveChanges();

                // Chuyển hướng đến trang "Login"
                return RedirectToAction("Login", "User");
            }

            return View(Model);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                var customer = db.Users.FirstOrDefault(k => k.username == user.UserName && k.password == user.Password);

                if (customer != null)
                {
                    Session["UserName"] = user.UserName;

                    return RedirectToAction("Index", "HomePage");
                }
                else
                {
                    ModelState.AddModelError("Password", "Tài khoản không tồn tại hoặc mật khẩu không đúng.");
                    return View(user);
                }
            }
            return View(user);
        }



        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return Redirect("~/");
        }


        [HttpGet]
        public ActionResult Participant()
        {
            return View();
        }

        // Action method cho HTTP POST request để xử lý dữ liệu khi người dùng submit form
        [HttpPost]
        public ActionResult Participant(Participant model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu, ví dụ lưu vào cơ sở dữ liệu
                // Ở đây tôi chỉ in ra một thông báo để minh họa
                Console.WriteLine("Registration successful for: " + model.name);

                // Chuyển hướng đến một trang khác để hiển thị thông báo thành công
                return RedirectToAction("Success");
            }
            else
            {
                // Nếu dữ liệu không hợp lệ, hiển thị lại form với các thông báo lỗi
                return View(model);
            }
        }

        public ActionResult Success()
        {
           
            ViewBag.Message = "Registration successful!"; // Thông báo thành công
            return View();
        }
    }
}
