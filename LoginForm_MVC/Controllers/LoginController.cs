using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginForm_MVC.Models;

namespace LoginForm_MVC.Controllers
{
    public class LoginController : Controller
    {
        LoginDbEntities db=new LoginDbEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if(ModelState.IsValid==true)
            {
                var credentials = db.Users.Where(model => model.Username == user.Username && model.Password == user.Password).FirstOrDefault(); 
                if(credentials ==null)
                {
                        ViewBag.Errormessage = "Login Failed";
                        return View();   
                }
                else
                {
                    if (user.Username == "Manager" && user.Password == "Manager")
                    {
                        Console.WriteLine("This is manager module");
                    }
                    else if (user.Username == "Staff" && user.Password == "Staff")
                    {
                        Console.WriteLine("This is Staff module");
                    }
                    else if (user.Username == "Customer" && user.Password == "Customer")
                    {
                        Console.WriteLine("This is Customer module");
                    }
                    Session["username"] = user.Username;
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }

      public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}