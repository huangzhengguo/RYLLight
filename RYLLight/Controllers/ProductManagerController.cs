using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RYLLight.Controllers
{
    public class ProductManagerController : RyllightController
    {
        // GET: ProductManager
        // 添加用户验证，只有验证后才能登录管理
        // [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}