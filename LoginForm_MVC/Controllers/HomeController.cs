using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginForm_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index","Login");

            }
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        
    }
}