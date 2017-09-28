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
    public class ProductScenesController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: ProductScenes
        public ActionResult Index()
        {
            return View(db.ProductScenes.ToList());
        }

        // GET: ProductScenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductScene productScene = db.ProductScenes.Find(id);
            if (productScene == null)
            {
                return HttpNotFound();
            }
            return View(productScene);
        }

        // GET: ProductScenes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductScenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SceneName,SceneDescription,ScenePicturePath")] ProductScene productScene)
        {
            if (ModelState.IsValid)
            {
                db.ProductScenes.Add(productScene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productScene);
        }

        // GET: ProductScenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductScene productScene = db.ProductScenes.Find(id);
            if (productScene == null)
            {
                return HttpNotFound();
            }
            return View(productScene);
        }

        // POST: ProductScenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SceneName,SceneDescription,ScenePicturePath")] ProductScene productScene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productScene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productScene);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUploadFile(ProductScene productScene, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    int index = 0;
                    string filePrefixName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                                DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                                                DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    foreach (var f in file)
                    {
                        // 如果文件为空的话直接跳出循环
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
                                productScene.ApplicationScenePicturePath = "/Upload/" + filePrefixName + fileSuffixName;
                            }else if (index == 1)
                            {
                                productScene.ScenePicturePath = "/Upload/" + filePrefixName + fileSuffixName;
                            }
                        }
                        catch
                        {
                            return Content("上传异常!", "text/plain");
                        }

                        index++;
                    }
                }

                db.Entry(productScene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productScene);
        }

        // GET: ProductScenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductScene productScene = db.ProductScenes.Find(id);
            if (productScene == null)
            {
                return HttpNotFound();
            }
            return View(productScene);
        }

        // POST: ProductScenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductScene productScene = db.ProductScenes.Find(id);
            db.ProductScenes.Remove(productScene);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadFile(ProductScene productScene, HttpPostedFileBase[] file)
        {
            // 所有的文件依次存储在file数组中，然后依次存储
            if (file == null)
            {
                return Content("没有文件!", "text/plain");
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
                        productScene.ApplicationScenePicturePath = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                    else if (index == 1)
                    {
                        productScene.ScenePicturePath = "/Upload/" + filePrefixName + fileSuffixName;
                    }
                }
                catch
                {
                    return Content("上传异常!", "text/plain");
                }

                index++;
            }

            // 保存到数据库
            db.ProductScenes.Add(productScene);
            db.SaveChanges();

            // 重定向到列表界面
            return RedirectToAction("Index");
        }

        // 添加产品
        public ActionResult AddProduct(int id)
        {
            // 重定向到产品列表，并把场景的的id传递过去，显示指定场景的产品
            return RedirectToRoute(new { controller="Products",action= "DisplayProductForScene", sceneId = id });
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
