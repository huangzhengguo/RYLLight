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
    public class CompanyInfoesController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: CompanyInfoes
        public ActionResult Index()
        {
            return View(db.CompanyInfos.ToList());
        }

        // GET: CompanyInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfos.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,CompanyAddress,PhoneNumber,MailBox,CompanyDescription,FreeOne,FreeTwo,FreeThree")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                db.CompanyInfos.Add(companyInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyInfo);
        }

        // GET: CompanyInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfos.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,CompanyAddress,PhoneNumber,MailBox,CompanyDescription,FreeOne,FreeTwo,FreeThree")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyInfo companyInfo = db.CompanyInfos.Find(id);
            if (companyInfo == null)
            {
                return HttpNotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyInfo companyInfo = db.CompanyInfos.Find(id);
            db.CompanyInfos.Remove(companyInfo);
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

        [HttpPost]
        public ActionResult EditCompanyInfo(CompanyInfo companyInfo, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                bool isUploadSuccess = ProcessUploadFiles(companyInfo, file);
                if (isUploadSuccess == false)
                {
                    return Content("上传异常!", "text/plain");
                }

                db.Products.Include("ProductScene");
                db.Entry(companyInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", companyInfo);
        }

        [HttpPost]
        public ActionResult UploadCompanyInfoFile(CompanyInfo companyInfo,HttpPostedFileBase[] file)
        {
            if (file == null)
            {
                return Content("没有文件", "text/plain");
            }

            bool isUploadSuccess = ProcessUploadFiles(companyInfo, file);
            if(isUploadSuccess == false)
            {
                return Content("上传异常");
            }

            db.CompanyInfos.Add(companyInfo);
            db.SaveChanges();

            // 返回公司信息
            return View("Index",db.CompanyInfos);
        }

        bool ProcessUploadFiles(CompanyInfo companyInfo, HttpPostedFileBase[] file)
        {
            int index = 0;
            string filePrefixName = GetDataTimeStr();
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
                        companyInfo.FreeOne = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                    else if (index == 1)
                    {
                        companyInfo.FreeTwo = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                    else if (index == 2)
                    {
                        companyInfo.FreeThree = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                    else if (index == 3)
                    {
                        companyInfo.CompanyBackgroundImg = "/Upload/" + filePrefixName + fileSuffixName;
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
    }
}
