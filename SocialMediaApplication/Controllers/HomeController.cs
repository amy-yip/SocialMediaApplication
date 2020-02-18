using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SocialMediaApplication.Controllers
{
    public class HomeController : Controller
    {
        Models.ClientsEntities database = new Models.ClientsEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string username = collection["username"];
            Models.User theUser = database.Users.SingleOrDefault(u => u.username.Equals(username));

            if (theUser != null && Crypto.VerifyHashedPassword(theUser.password_hash, collection["password_hash"]))
            {
                Session["user_id"] = theUser.user_id;
                return RedirectToAction("Index", "Profile");
            }

            else
            {
                ViewBag.error = "Wrong Username/Password Combination!";
                return View();
            }     
          
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }


        // GET: Home/Register
        public ActionResult Register()
        {
            return View();
        }



        // POST: Home/Register
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                string username = collection["username"];

                Models.User theUser = database.Users.SingleOrDefault(u => u.username.Equals(username));

                if(theUser != null)
                {
                    return RedirectToAction("Register");
                }

                Models.User newUser = new Models.User()
                {
                    username = collection["username"],
                    password_hash = Crypto.HashPassword(collection["password_hash"])
                };

                database.Users.Add(newUser);
                database.SaveChanges();

                return RedirectToAction("Index");
            }

            catch
            {
                return View();
            }
        }

     



    }
}
