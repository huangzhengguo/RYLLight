using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RYLLight.Models;

namespace RYLLight.Controllers
{
    public class LogoesController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: Logoes
        public ActionResult Index()
        {
            return View(db.Logos.ToList());
        }

        // GET: Logoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = db.Logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // GET: Logoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Active,PicturePath")] Logo logo)
        {
            if (ModelState.IsValid)
            {
                db.Logos.Add(logo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logo);
        }

        // GET: Logoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = db.Logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Logoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Active,PicturePath")] Logo logo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logo);
        }

        // GET: Logoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logo logo = db.Logos.Find(id);
            if (logo == null)
            {
                return HttpNotFound();
            }
            return View(logo);
        }

        // POST: Logoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logo logo = db.Logos.Find(id);
            db.Logos.Remove(logo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // 上传图片
        [HttpPost]
        // public ActionResult 

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
