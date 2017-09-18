using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RYLLight.Models;
using System.IO;

namespace RYLLight.Controllers
{
    public class PreviewProductsController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: PreviewProducts
        public async Task<ActionResult> Index()
        {
            var previewProducts = db.PreviewProducts.Include(p => p.Product);
            return View(await previewProducts.ToListAsync());
        }

        // GET: PreviewProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviewProduct previewProduct = await db.PreviewProducts.FindAsync(id);
            if (previewProduct == null)
            {
                return HttpNotFound();
            }
            return View(previewProduct);
        }

        // GET: PreviewProducts/Create
        public ActionResult Create(int productId)
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode");
            ViewBag.currentProductId = productId;
            foreach (var item in ViewBag.ProductId)
            {
                string str = item.Value;
                if (str.Equals(productId.ToString()))
                {
                    item.Selected = true;
                }else
                {
                    item.Selected = false;
                }
            }
            return View();
        }

        // POST: PreviewProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PictureName,ProductPicturePath,ProductId")] PreviewProduct previewProduct)
        {
            if (ModelState.IsValid)
            {
                db.PreviewProducts.Add(previewProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", previewProduct.ProductId);
            return View(previewProduct);
        }

        // GET: PreviewProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviewProduct previewProduct = await db.PreviewProducts.FindAsync(id);
            if (previewProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", previewProduct.ProductId);
            return View(previewProduct);
        }

        // POST: PreviewProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PictureName,ProductPicturePath,ProductId")] PreviewProduct previewProduct,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                bool isUploadSuccess = ProcessFile(previewProduct, file);
                if (isUploadSuccess == false)
                {
                    return Content("上传异常！", "text/plain");
                }

                db.Entry(previewProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductCode", previewProduct.ProductId);
            return View(previewProduct);
        }

        // GET: PreviewProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreviewProduct previewProduct = await db.PreviewProducts.FindAsync(id);
            if (previewProduct == null)
            {
                return HttpNotFound();
            }
            return View(previewProduct);
        }

        // POST: PreviewProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PreviewProduct previewProduct = await db.PreviewProducts.FindAsync(id);
            db.PreviewProducts.Remove(previewProduct);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // 从这个方法中进入预览图片列表界面
        public ActionResult DisplayPreviewPictureForProduct(int productId)
        {
            var previewProductsList = from prev in db.PreviewProducts
                                      where prev.ProductId == productId
                                      select prev;

            ViewBag.productId = productId;
            return View("Index",previewProductsList.ToList());
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

        // 保存新建的预览图片
        public ActionResult UploadFile(PreviewProduct previewProduct, HttpPostedFileBase file)
        {

            bool isUploadSuccess = ProcessFile(previewProduct, file);
            if (isUploadSuccess == false)
            {
                return Content("上传异常！", "text/plain");
            }

            db.PreviewProducts.Add(previewProduct);
            db.SaveChanges();

            return RedirectToAction("DisplayPreviewPictureForProduct", new { productId = previewProduct.ProductId });
        }

        // 处理表单文件
        private bool ProcessFile(PreviewProduct previewProduct, HttpPostedFileBase file)
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
                previewProduct.ProductPicturePath = "/Upload/" + filePrefixName + fileSuffixName;
            }
            catch
            {
                return false;
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
