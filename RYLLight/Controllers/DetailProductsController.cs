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
    public class DetailProductsController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: DetailProducts
        public ActionResult Index()
        {
            var detailProducts = db.DetailProducts.Include(d => d.Product);
            return View(detailProducts.ToList());
        }

        // GET: DetailProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }
            return View(detailProduct);
        }

        // GET: DetailProducts/Create
        public ActionResult Create(int productId)
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode");

            // 列表默认选中当前产品
            foreach (var item in ViewBag.ProductId)
            {
                string str = item.Value;
                if (str.Equals(productId))
                {
                    // 选中当前项
                    item.Selected = true;
                }
                else
                {
                    // 其他选项设置未选中
                    item.Selected = false;
                }
            }
            return View();
        }

        // POST: DetailProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,ProductCode,ProductPower,ProductLumen,ProductColorAngle,ProductId")] DetailProduct detailProduct)
        {
            if (ModelState.IsValid)
            {
                db.DetailProducts.Add(detailProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", detailProduct.ProductId);
            return View(detailProduct);
        }

        // GET: DetailProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", detailProduct.ProductId);
            return View(detailProduct);
        }

        // POST: DetailProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,ProductType,ProductCode,ProductPower,ProductLumen,ProductColorAngle,ProductId,DetailProductPicturePath")] DetailProduct detailProduct,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                // 处理文件
                bool isUploadSuccess = ProcessFile(detailProduct, file);
                if (isUploadSuccess == false)
                {
                    return Content("上传异常！", "text/plain");
                }

                db.Entry(detailProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", detailProduct.ProductId);
            return View(detailProduct);
        }

        // GET: DetailProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            if (detailProduct == null)
            {
                return HttpNotFound();
            }
            return View(detailProduct);
        }

        // POST: DetailProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailProduct detailProduct = db.DetailProducts.Find(id);
            db.DetailProducts.Remove(detailProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DisplayDetailPictureForProduct(int productId)
        {
            var detailProductsList = from d in db.DetailProducts
                                     where d.ProductId == productId
                                     select d;
            ViewBag.productId = productId;
            return View("Index", detailProductsList.ToList());
        }

        // 显示特点图标
        public ActionResult UploadFile(DetailProduct detailProduct, HttpPostedFileBase file)
        {
            // 处理文件
            bool isUploadSuccess = ProcessFile(detailProduct, file);
            if (isUploadSuccess == false)
            {
                return Content("上传异常！", "text/plain");
            }

            db.DetailProducts.Add(detailProduct);
            db.SaveChanges();

            return RedirectToAction("DisplayDetailPictureForProduct", new { productId = detailProduct.ProductId });
        }

        private bool ProcessFile(DetailProduct detailProduct, HttpPostedFileBase file)
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
                detailProduct.DetailProductPicturePath = "/Upload/" + filePrefixName + fileSuffixName;
            }
            catch
            {
                return false;
            }

            return true;
        }

        // 返回产品列表
        public ActionResult BackToProductList(int productId)
        {
            // 获取到产品
            Product product = (from p in db.Products
                               where p.Id == productId
                               select p).ToList()[0];

            return RedirectToRoute(new { controller = "Products", action = "DisplayProductForScene", sceneId = product.ProductSceneId });
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
