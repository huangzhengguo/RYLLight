using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RYLLight.Controllers
{
    public class AdminManagerController : Controller
    {
        // GET: AdminManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
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

        // GET: AdminManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminManager/Edit/5
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

        // GET: AdminManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminManager/Delete/5
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
