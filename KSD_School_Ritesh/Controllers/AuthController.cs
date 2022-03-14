using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSD_School_Ritesh.DAL;
using KSD_School_Ritesh.Models;

namespace KSD_School_Ritesh.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(login loginda)
        {
            LoginDAL loginDA = new LoginDAL();
            string role = loginDA.LoginCheck(loginda);
            
            if (role == "admin")
            {
                Session["Username"] = loginda.Username;
                return RedirectToAction("staff","home" );
            }
            
            if (role == "student")
            {
                Session["Username"] = loginda.Username;
                return RedirectToAction("student", "home");
            }
            
            if (role == "teacher")
            {
                Session["Username"] = loginda.Username;
                return RedirectToAction("fees", "home");
            }
            else
            {
                return View();
            }


        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(login loginda)
        {
            RegisterDAL loginDA = new RegisterDAL();

            int res = loginDA.Register(loginda);
            
                if (res == 1 && loginda.Role=="student")
                {
                    Response.Redirect("/Auth/studentdata");
                }

            return View();

        }

        public ActionResult studentdata()
        {
            return View();
        }



        [HttpPost]
        public ActionResult studentdata(Student loginda)
        {
            RegisterDAL loginDA = new RegisterDAL();

            int res = loginDA.Addstudent(loginda);

            if (res == 1)
            {
                Response.Redirect("/Auth/login");
            }

            return View();
        }
        
    }
}