using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMediaApplication.Controllers
{
    public class ProfileController : Controller
    {
        Models.ClientsEntities database = new Models.ClientsEntities();

        // GET: Profile
        public ActionResult Index()
        {
            if(Session["user_id"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(database.Profiles);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            if(Session["user_id"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            if(Session["user_id"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            if (Session["user_id"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                // TODO: Add insert logic here
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
