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
    public class ProductFeaturesController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: ProductFeatures
        public ActionResult Index()
        {
            var productFeature = db.ProductFeature.Include(p => p.Product);
            return View(productFeature.ToList());
        }

        // GET: ProductFeatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeature.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            return View(productFeature);
        }

        // GET: ProductFeatures/Create
        public ActionResult Create(int productId)
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode");

            // 列表默认选中当前产品
            foreach(var item in ViewBag.ProductId)
            {
                string str = item.Value;
                if (str.Equals(productId))
                {
                    // 选中当前项
                    item.Selected = true;
                }else
                {
                    // 其他选项设置未选中
                    item.Selected = false;
                }
            }

            return View();
        }

        // POST: ProductFeatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductFeatureName,ProductFeaturePicturePath,ProductId")] ProductFeature productFeature)
        {
            if (ModelState.IsValid)
            {
                db.ProductFeature.Add(productFeature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", productFeature.ProductId);
            return View(productFeature);
        }

        // GET: ProductFeatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeature.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", productFeature.ProductId);
            return View(productFeature);
        }

        // POST: ProductFeatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductFeatureName,ProductFeaturePicturePath,ProductId")] ProductFeature productFeature,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // 处理文件
                bool isUploadSuccess = ProcessFile(productFeature, file);
                if (isUploadSuccess == false)
                {
                    return Content("文件上传异常！", "text/plain");
                }

                db.Entry(productFeature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", productFeature.ProductId);
            return View(productFeature);
        }

        // GET: ProductFeatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductFeature productFeature = db.ProductFeature.Find(id);
            if (productFeature == null)
            {
                return HttpNotFound();
            }
            return View(productFeature);
        }

        // POST: ProductFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductFeature productFeature = db.ProductFeature.Find(id);
            db.ProductFeature.Remove(productFeature);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // 显示特点图标
        public ActionResult UploadFile(ProductFeature featureProduct, HttpPostedFileBase file)
        {
            // 处理文件
            bool isUploadSuccess = ProcessFile(featureProduct, file);
            if (isUploadSuccess == false)
            {
                return Content("文件上传异常！", "text/plain");
            }

            db.ProductFeature.Add(featureProduct);
            db.SaveChanges();

            return RedirectToAction("DisplayFeaturePictureForProduct", new { productId = featureProduct.ProductId });
        }

        private bool ProcessFile(ProductFeature featureProduct, HttpPostedFileBase file)
        {
            if (file == null)
            {
                return true;
            }

            string filePrefixName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            string fileSuffixName = file.FileName.Substring(file.FileName.LastIndexOf("."));
            var filePath = Path.Combine(Request.MapPath("~/Upload"), filePrefixName + fileSuffixName);
            try
            {
                file.SaveAs(filePath);
                featureProduct.ProductFeaturePicturePath = "/Upload/" + filePrefixName + fileSuffixName;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public ActionResult DisplayFeaturePictureForProduct(int productId)
        {
            // 查询特点图标图片
            var featureList = from feature in db.ProductFeature
                              where feature.ProductId == productId
                              select feature;

            ViewBag.productId = productId;
            // 把选择到的图片传递给视图展示
            return View("Index", featureList);
        }
        
        // 返回产品列表
        public ActionResult BackToProductList(int productId)
        {
            // 获取到产品
            Product product = (from p in db.Products
                              where p.Id == productId
                              select p).ToList()[0];

            return RedirectToRoute(new { controller = "Products", action = "DisplayProductForScene" , sceneId = product.ProductSceneId});
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
