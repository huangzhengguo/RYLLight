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
    public class ProductsController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create(int sceneId)
        {
            // 把应用场景的列表数据传递到视图中
            ViewBag.ProductSceneId = new SelectList(db.ProductScenes, "Id", "SceneName");

            // 列表默认选中当前产品
            foreach (var item in ViewBag.ProductSceneId)
            {
                string str = item.Value;
                if (str.Equals(sceneId))
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

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProductCode,ProductName,ProductType,ProductDes,ApplicationScenarios,ApplicationScenariosPicturePath,ProductPower,ProductLength,ProductLumen,ProductPicturePath,ProductGuide,ProductInstallationGuide,ProductDatasheet,ProductIes")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProductCode,ProductName,ProductType,ProductDes,ApplicationScenarios,ApplicationScenariosPicturePath,ProductPower,ProductLength,ProductLumen,ProductPicturePath,ProductGuide,ProductInstallationGuide,ProductDatasheet,ProductIes")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpLoadEdit(Product product, HttpPostedFileBase[] file)
        {
            if (ModelState.IsValid)
            {
                bool isUploadSuccess = EditProductWithFile(product, file);
                if (isUploadSuccess == false)
                {
                    return Content("上传异常!", "text/plain");
                }

                db.Products.Include("ProductScene");
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // 上传文件处理方法：处理上传文件并保存
        [HttpPost]
        public ActionResult UploadFile(Product product,HttpPostedFileBase[] file)
        {
            // 所有的文件依次存储在file数组中，然后依次存储
            if (file == null)
            {
                return Content("没有文件!", "text/plain");
            }

            bool isUploadSuccess = EditProductWithFile(product, file);
            if (isUploadSuccess == false)
            {
                return Content("上传异常!", "text/plain");
            }

            // 保存到数据库
            db.Products.Add(product);
            db.SaveChanges();

            // 重定向到列表界面
            return RedirectToAction("DisplayProductForScene",new { sceneId = product.ProductSceneId });
        }

        private bool EditProductWithFile(Product product, HttpPostedFileBase[] file)
        {
            int index = 0;
            foreach (var f in file)
            {
                // 如果没有选择文件，继续执行循环
                if (f == null)
                {
                    index++;
                    continue;
                }

                string fileName = f.FileName;
                var filePath = Path.Combine(Request.MapPath("~/Upload"), fileName);
                try
                {
                    f.SaveAs(filePath);
                    if (index == 0)
                    {
                        product.ProductPicturePath = "/Upload/" + fileName;
                    }
                    else if (index == 1)
                    {
                        product.MobileProductPicturePath = "/Upload/" + fileName;
                    }
                    else if (index == 2)
                    {
                        product.ProductBackgroundImage = "/Upload/" + fileName;
                    }
                    else if (index == 3)
                    {
                        product.ApplicationScenePath = "/Upload/" + fileName;
                    }
                    else if (index == 4)
                    {
                        product.Spectrum = "/Upload/" + fileName;
                    }
                    else if (index == 5)
                    {
                        product.ProductGuide = "/Upload/" + fileName;
                    }
                    else if (index == 6)
                    {
                        product.ProductInstallationGuide = "/Upload/" + fileName;
                    }
                    else if (index == 7)
                    {
                        product.ProductDatasheet = "/Upload/" + fileName;
                    }
                    else if (index == 9)
                    {
                        product.ProductIes = "/Upload/" + fileName;
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

        // 跳转到产品详情页面：获取所有的详细信息:三级页面
        public ActionResult ProductDetailInfo(int productId)
        {
            // 根据产品Id获取产品信息 预览信息 图标信息 具体规格信息
            // 获取产品信息
            int id = productId;
            if (id == 23)
            {
                id = 15;
            }else if (id == 24)
            {
                id = 16;
            }
            var product = (from p in db.Products.Include("ProductScene")
                          where p.Id == id
                          select p).ToList<Product>()[0];
            // 获取园预览图片
            List<PreviewProduct> preViewProductList = (from p in db.PreviewProducts
                                     where p.ProductId == id
                                                       select p).ToList();
            // 获取图标
            List<ProductFeature> featureList = (from f in db.ProductFeature
                              where f.ProductId == id
                                                select f).ToList();
            // 获取规格图片
            List<DetailProduct> detailProductList = (from p in db.DetailProducts
                                    where p.ProductId == id
                                                     select p).ToList();
            ViewBag.product = product;
            ViewBag.preViewProductList = preViewProductList;
            ViewBag.featureList = featureList;
            ViewBag.detailProductList = detailProductList;

            ViewBag.NavTitle = product.ProductType + " /" + product.ProductName + " /" + product.ProductCode;

            return View();
        }

        // 显示指定场景的产品
        public ActionResult DisplayProductForScene(int sceneId)
        {
            // 显示指定场景的产品
            var productList = from p in db.Products
                              where p.ProductSceneId == sceneId
                              select p;
            ViewBag.sceneId = sceneId;
            return View("Index", productList.ToList());
        }

        // 跳转到添加预览图片
        public ActionResult AddPreview(int id)
        {
            // 通过路由重定向到
            return RedirectToRoute(new { controller= "PreviewProducts" ,action= "DisplayPreviewPictureForProduct", productId = id});
        }

        // 跳转到添加特点图标
        public ActionResult AddFeatureIcon(int id)
        {
            return RedirectToRoute(new { controller= "ProductFeatures", action= "DisplayFeaturePictureForProduct", productId =id});
        }

        // 跳转到添加子产品页面
        public ActionResult AddDetailProducts(int id)
        {
            return RedirectToRoute(new { controller = "DetailProducts", action = "DisplayDetailPictureForProduct", productId = id });
        }

        // 返回场景页面
        public ActionResult BackToSceneList()
        {
            return RedirectToRoute(new { controller= "ProductScenes" ,action="Index"});
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
