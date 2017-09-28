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
    public class CarouselsController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: Carousels
        public ActionResult Index()
        {
            return View(db.Carousels.ToList());
        }

        // GET: Carousels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = db.Carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        // GET: Carousels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carousels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PicturePath,SortNumber,TypeProduct,PictureName,PictureDes,PictureTitle")] Carousel carousel)
        {
            if (ModelState.IsValid)
            {
                db.Carousels.Add(carousel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carousel);
        }

        // GET: Carousels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = db.Carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        // POST: Carousels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PicturePath,SortNumber,PictureName,PictureDes,PictureTitle")] Carousel carousel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carousel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carousel);
        }

        // 编辑
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUploadFile([Bind(Include = "Id,PicturePath,MobilePicturePath,TypeProduct,SortNumber,PictureName,PictureDes,PictureTitle")] Carousel carousel, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                // 所有的文件依次存储在file数组中，然后依次存储
                bool isUploadSuccess = UploadMultiFile(carousel, file);
                if (isUploadSuccess == false)
                {
                    return Content("上传文件异常!", "text/plain");
                }

                // 保存到数据库
                db.Entry(carousel).State = EntityState.Modified;
                db.SaveChanges();

                // 重定向到列表界面
                return RedirectToAction("Index");
            }

            return View("Edit",carousel);
        }

        // GET: Carousels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carousel carousel = db.Carousels.Find(id);
            if (carousel == null)
            {
                return HttpNotFound();
            }
            return View(carousel);
        }

        // POST: Carousels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carousel carousel = db.Carousels.Find(id);
            db.Carousels.Remove(carousel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /* 上传文件
         * 1.在后台利用HttpPostedFileBase来接收上传的文件，该类为一个抽象类，但在
         * ASP.NET web form却没有此类，此类的出现是为了更好的进行单元测试
         * 2.在视图中文件类型的name要和后台接收文件的参数名一直：都是name
         */

        [HttpPost]
        public ActionResult UploadFile(Carousel carousel, HttpPostedFileBase[] file)
        {
            // 所有的文件依次存储在file数组中，然后依次存储
            bool isUploadSuccess = UploadMultiFile(carousel, file);
            if (isUploadSuccess == false)
            {
                return Content("上传文件异常!","text/plain");
            }

            // 保存到数据库
            db.Carousels.Add(carousel);
            db.SaveChanges();

            // 重定向到列表界面
            return RedirectToAction("Index");
        }

        private bool UploadMultiFile(Carousel carousel, HttpPostedFileBase[] file)
        {
            if (file == null)
            {
                return false;
            }

            int index = 0;
            string filePrefixName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            foreach (var f in file)
            {
                if (f == null)
                {
                    index ++;
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
                    // 一共有两个场景图片
                    if (index == 0)
                    {
                        carousel.PicturePath = "/Upload/" + filePrefixName + fileSuffixName;
                    }else if (index == 1)
                    {
                        carousel.MobilePicturePath = "/Upload/" + filePrefixName + fileSuffixName;
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
