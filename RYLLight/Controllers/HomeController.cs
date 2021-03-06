﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using RYLLight.Models;

namespace RYLLight.Controllers
{
    public class HomeController : RyllightController
    {
        private RyllightEntities db = new RyllightEntities();

        public HomeController()
        {
        }

        /// <summary>
        /// 网站首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("InledcoIndex");
        }

        /// <summary>
        /// 商业照明首页
        /// </summary>
        /// <returns></returns>
        public ActionResult InledcoIndex()
        {
            // 传递轮播图数据
            var carousel = from c in Context.Carousels
                           where c.TypeProduct != TypeOfProduct.HORTICULTURE
                           orderby c.SortNumber ascending
                           select c;

            // 提供默认的轮播图:防止从数据库中读取到的数据为0
            if (carousel.Count() == 0)
            {
                return Content("缺少轮播图!");
            }

            // 传递产品数据
            /*
             排除23 24两个产品
             */
            ViewBag.products = (from p in Context.Products
                                where p.Id != 23 && p.Id != 24 && p.ProductType != TypeOfProduct.HORTICULTURE
                                select p).ToList();

            return View("Index",carousel);
        }

        /**
         * 网站总体设计：
         * 1.总的首页有一个灯具分类入口，比如，植物灯、商业照明等等，点击不同的分类，进入不同的灯具首页
         * 2.分类首页，分别进入不同种类的灯具的首页，每个分类的首页展示的是不同种类的灯具
         */
        /// <summary>
        /// 植物灯首页
        /// </summary>
        /// <returns></returns>
        public ActionResult PlantIndex()
        {
            // 获取植物灯页面菜单
            MenuList = (from menu in Context.Menus
                        where menu.FreeOne == "Plant"
                        orderby menu.Sortnumber ascending
                        select menu).ToList<Menu>();
            string productType = types.ToList<ProductTypes>()[(int)TypeOfProduct.HORTICULTURE].ProductTypeName;

            ViewBag.MenuList = MenuList;

            // 1.获取轮播图，轮播图使用强类型，其它使用ViewBag传递
            var carousel = from c in Context.Carousels
                           where c.TypeProduct == TypeOfProduct.HORTICULTURE
                           orderby c.SortNumber ascending
                           select c;
            if (carousel.Count() == 0)
            {
                return Content("缺少轮播图！");
            }

            // 2.获取新闻数据
            var news = (from c in Context.CompanyNews
                        where c.PublishOrNot == true && c.TypeProduct == TypeOfProduct.HORTICULTURE
                        orderby c.SortNumber
                        select c).Take(2).ToList();

            ViewBag.news = news;

            // 3.获取应用分类，获取时按照id排序
            var scenes = (from s in Context.ProductScenes
                          where s.FreeOne == productType
                          orderby s.Id
                          select s).ToList();
            ViewBag.scenes = scenes;

            // 4.根据应用分类获取产品信息(默认是获取第一个场景对应的产品)，获取所有的产品，按照场景id排序
            if (scenes.Count > 0)
            {
                ProductScene productScene = scenes[0];
                var sceneProducts = (from p in Context.Products
                                     where p.ProductType == TypeOfProduct.HORTICULTURE
                                     orderby p.ProductSceneId
                                     select p).ToList();

                ViewBag.sceneProducts = sceneProducts;
            }

            // 5.获取公司信息
            List<CompanyInfo> companyList = (from p in db.CompanyInfos
                                             where p.TypeProduct == TypeOfProduct.HORTICULTURE
                                             select p).ToList();
            if (companyList.Count > 0)
            {
                ViewBag.companyInfo = companyList[0];
            }

            return View("Inledco", carousel);
        }

        /// <summary>
        /// 获取指定场景下的产品
        /// </summary>
        /// <param name="sceneId">场景ID</param>
        /// <returns></returns>
        public ActionResult GetProductWithScenedId(int sceneId)
        {
            List<Product> sceneProducts = (from p in db.Products
                                          where p.ProductSceneId == sceneId
                                          select p).ToList();

            ViewBag.sceneProducts = sceneProducts;

            return PartialView("ProductForSceneId");
        }

        /// <summary>
        /// 应用场景
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplicationScene()
        {
            // 返回View() 框架会自动查找对应的视图
            ViewBag.NavTitle = "APPLICATION";

            List<ProductScene> productSceneList = (from ps in db.ProductScenes.Include("Produts")
                                                   where ps.Id != 12
                                                  select ps).ToList();
            return View(productSceneList);
        }

        /// <summary>
        /// 场景产品
        /// </summary>
        /// <param name="sceneId"></param>
        /// <returns></returns>
        public ActionResult ProductInApplicationScene(int sceneId)
        {
            // 只能显示对应的产品
            ViewBag.index = 0;

            // 是否显示Product和Application切换按钮
            ViewBag.isShowButton = false;

            List<Product> productList = (from p in db.Products
                                         where p.ProductType == TypeOfProduct.LIGHTING && p.ProductSceneId == sceneId
                                         select p).ToList();

            List<ProductScene> sceneList = (from s in db.ProductScenes
                                            where s.Id == sceneId
                                            select s).ToList();
            if (sceneList.Count > 0)
            {
                ViewBag.NavTitle = "APPLICATION /" + sceneList[0].SceneName;
            }

            return View("Lighting", productList);
        }

        /// <summary>
        /// 商业照明产品
        /// </summary>
        /// <returns></returns>
        public ActionResult Lighting()
        {
            ViewBag.isShowButton = true;

            // 传递导航信息
            ViewBag.NavTitle = "LIGHTING";

            ViewBag.index = 0;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in db.Products.Include("ProductScene")
                                         where p.ProductType == TypeOfProduct.LIGHTING && p.Id != 23 && p.Id != 24
                                         select p).ToList();

            return View(productList);
        }

        /// <summary>
        /// 智能控制
        /// </summary>
        /// <returns></returns>
        public ActionResult Intellgentcontrol()
        {
            // 传递导航信息
            ViewBag.NavTitle = "INTELLGENTCONTROL";

            ViewBag.index = 0;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in db.Products
                                         where p.ProductType == TypeOfProduct.INTELLGENTCONTROL
                                         select p).ToList();

            return View(productList);
        }

        /// <summary>
        /// 植物照明
        /// </summary>
        /// <returns></returns>
        public ActionResult Horticulture()
        {
            // 传递导航信息
            ViewBag.NavTitle = "LED GROWLIGHT";

            ViewBag.index = 0;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in db.Products
                                         where p.ProductType == TypeOfProduct.HORTICULTURE
                                         select p).ToList();

            return View(productList);
        }

        /// <summary>
        /// 水族灯
        /// </summary>
        /// <returns></returns>
        public ActionResult Aquarium()
        {
            // 传递导航信息
            ViewBag.NavTitle = "ACQUARIUM";

            ViewBag.index = 0;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in db.Products
                                         where p.ProductType == TypeOfProduct.AQUARIUM
                                         select p).ToList();
            return View(productList);
        }

        /// <summary>
        /// 公司页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Company()
        {
            List<CompanyInfo> companyList = (from p in db.CompanyInfos
                                            select p).ToList();
            if (companyList.Count > 0)
            {
                ViewBag.ComanyInfo = companyList[0];
                return View();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 产品文件下载
        /// </summary>
        public ActionResult ProductFileDownload(bool isPlant = false)
        {
            MenuList = (from menu in Context.Menus
                        where menu.FreeOne == "Plant" && menu.MenuTitle == "Download"
                        orderby menu.Sortnumber ascending
                        select menu).ToList<Menu>();

            ViewBag.MenuList = MenuList;

            var productList = (from p in db.Products
                               orderby p.ProductName
                               select p).AsNoTracking()
                                        .ToList();
            ViewBag.isPlant = isPlant;

            return View(productList);
        }

        // 添加参数区分是点击的是product还是application
        public ActionResult LightingSort(int index)
        {
            ViewBag.isShowButton = true;

            ViewBag.index = index;
            // 点击Lighting菜单返回的视图：传递从数据库中读取到的，筛选出类别为lighting的
            // 这里因为点击Product和Application
            List<Product> productList = (from p in db.Products.Include("ProductScene")
                                        where p.ProductType == TypeOfProduct.LIGHTING
                                         select p).ToList();

            // 指定返回视图的名称
            return View("Lighting", db.Products.ToList());
        }
    }
}