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
    public class NewsController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: News
        public ActionResult Index()
        {
            return View(db.CompanyNews.ToList());
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.CompanyNews.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,SubTitle,TypeProduct,Content,Author,PublishDateTime,EditDateTime,PublishOrNot,SortNumber")] News news,
            HttpPostedFileBase[] file)
        {   
            // 上传文件
            bool isUpLoadSuccess = UpLoadFile(news, file);
            if (!isUpLoadSuccess)
            {
                return Content("文件上传失败!");
            }

            ModelState.Remove("Thumbnail");
            ModelState.Remove("Picture");
            ModelState.Remove("NewsBackgroundImg");

            if (ModelState.IsValid)
            {
                db.CompanyNews.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.CompanyNews.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news,
            HttpPostedFileBase[] file)
        {
            // 上传文件
            bool isUpLoadSuccess = UpLoadFile(news, file);
            if (!isUpLoadSuccess)
            {
                return View(news);
            }

            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        private bool UpLoadFile(News news, HttpPostedFileBase[] file)
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
                        news.Thumbnail = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                    else if (index == 1)
                    {
                        news.Picture = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                    else if (index == 2)
                    {
                        news.NewsBackgroundImg = "/Upload/" + filePrefixName + fileSuffixName;
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

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.CompanyNews.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.CompanyNews.Find(id);
            db.CompanyNews.Remove(news);
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
