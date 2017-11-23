using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RYLLight.Models;
using System.IO;

namespace RYLLight.Controllers
{
    public class SaleContactInfoesController : Controller
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: SaleContactInfoes
        public ActionResult Index()
        {
            return View(db.SaleContactInfos.ToList());
        }

        // GET: SaleContactInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleContactInfo saleContactInfo = db.SaleContactInfos.Find(id);
            if (saleContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(saleContactInfo);
        }

        // GET: SaleContactInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleContactInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,NickName,PhoneNumber,MailBox,Skype,FreeTwo,FreeThree")] SaleContactInfo saleContactInfo)
        {
            if (ModelState.IsValid)
            {
                db.SaleContactInfos.Add(saleContactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(saleContactInfo);
        }

        [HttpPost]
        public ActionResult CreateWithFile(SaleContactInfo saleContactInfo, HttpPostedFileBase[] file)
        {
            // 所有的文件依次存储在file数组中，然后依次存储
            if (file == null)
            {
                return Content("没有文件!", "text/plain");
            }

            bool isUploadSuccess = EditSaleContactsWithFile(saleContactInfo, file);
            if (isUploadSuccess == false)
            {
                return Content("上传异常!", "text/plain");
            }

            // 保存到数据库
            db.SaleContactInfos.Add(saleContactInfo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditWithFile(SaleContactInfo saleContactInfo, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                bool isUploadSuccess = EditSaleContactsWithFile(saleContactInfo, file);
                if (isUploadSuccess == false)
                {
                    return Content("上传异常!", "text/plain");
                }

                db.Products.Include("ProductScene");
                db.Entry(saleContactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", saleContactInfo);
        }

        private bool EditSaleContactsWithFile(SaleContactInfo saleContactInfo, HttpPostedFileBase[] file)
        {
            int index = 0;
            string filePrefixName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            foreach (var f in file)
            {
                // 如果没有选择文件，继续执行循环
                if (f == null)
                {
                    index++;
                    continue;
                }

                // 根据上传时间重新命名文件
                filePrefixName = filePrefixName + index.ToString();

                // 获取文件后缀名
                string fileSuffixName = f.FileName.Substring(f.FileName.LastIndexOf("."));
                var filePath = Path.Combine(Request.MapPath("~/Upload"), filePrefixName + fileSuffixName);
                try
                {
                    f.SaveAs(filePath);
                    if (index == 0)
                    {
                        saleContactInfo.FreeOne = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                  
                }
                catch
                {
                    return false;
                }

                index++;
            }

            return true;
        }

        // GET: SaleContactInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleContactInfo saleContactInfo = db.SaleContactInfos.Find(id);
            if (saleContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(saleContactInfo);
        }

        // POST: SaleContactInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,NickName,PhoneNumber,MailBox,Skype,FreeOne,FreeTwo,FreeThree")] SaleContactInfo saleContactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleContactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saleContactInfo);
        }

        // GET: SaleContactInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleContactInfo saleContactInfo = db.SaleContactInfos.Find(id);
            if (saleContactInfo == null)
            {
                return HttpNotFound();
            }
            return View(saleContactInfo);
        }

        // POST: SaleContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleContactInfo saleContactInfo = db.SaleContactInfos.Find(id);
            db.SaleContactInfos.Remove(saleContactInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
