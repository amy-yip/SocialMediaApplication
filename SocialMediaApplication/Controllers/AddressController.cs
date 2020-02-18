using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMediaApplication.Controllers
{
    public class AddressController : Controller
    {
        Models.ClientsEntities database = new Models.ClientsEntities();

        // GET: Address
        public ActionResult Index(int id)
        {
            ViewBag.id = id;

            Models.Profile theProfile = database.Profiles.SingleOrDefault(p => p.profile_id == id);
            return View(theProfile);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            Models.Address theAddress = database.Addresses.SingleOrDefault(a => a.address_id == id);
            return View(theAddress);
        }

        // GET: Address/Create
        public ActionResult Create(int id)
        {
            ViewBag.theProfile = database.Profiles.SingleOrDefault(p => p.profile_id == id);
            ViewBag.countries = database.Countries.Select(c => new SelectListItem() { Value = c.country_code, Text = c.country_name });
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Address newAddress = new Models.Address()
                {
                    city = collection["city"],
                    country_code = collection["country_code"],
                    description = collection["description"],
                    profile_id = id,
                    province_state = collection["province_state"],
                    street = collection["street"],
                    zip_postal = collection["zip_postal"]
                };
                database.Addresses.Add(newAddress);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = newAddress.profile_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Address theAddress = database.Addresses.SingleOrDefault(c => c.address_id == id);
            ViewBag.countries = database.Countries.Select(c => new SelectListItem() { Value = c.country_code, Text = c.country_name });

            return View(theAddress);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Address theAddress = database.Addresses.SingleOrDefault(c => c.address_id == id);

                theAddress.city = collection["city"];
                theAddress.country_code = collection["country_code"];
                theAddress.description = collection["description"];
                theAddress.province_state = collection["province_state"];
                theAddress.street = collection["street"];
                theAddress.zip_postal = collection["zip_postal"];


                database.SaveChanges();

                return RedirectToAction("Index", new { id = theAddress.profile_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Address theAddress = database.Addresses.SingleOrDefault(c => c.address_id == id);
            return View(theAddress);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Address theAddress = database.Addresses.SingleOrDefault(c => c.address_id == id);
                database.Addresses.Remove(theAddress);
                database.SaveChanges();

                return RedirectToAction("Index", new { id = theAddress.profile_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
