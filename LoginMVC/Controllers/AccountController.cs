using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        UserDataEntities db = new UserDataEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegister ur)
        {
            if (ModelState.IsValid)
            {
                if(db.UserRegisters.Any(x => x.Email == ur.Email))
                {
                    ViewBag.Message = "Email already registered!";
                }
                else
                {
                    db.UserRegisters.Add(ur); 
                    db.SaveChanges();
                    Response.Write("<script>alert('Registration Successful')</script>");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Login (MyLogin l)
        {
            var query = db.UserRegisters.SingleOrDefault(m => m.Email == l.Email && m.Password == l.Password);

            if(query != null)
            {
                Response.Write("<script>alert('Login Successful')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid Credentials')</script>");
            }
            return View();
        }
    }
}