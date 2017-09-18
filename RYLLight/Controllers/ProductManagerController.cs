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
        public ActionResult Index()
        {
            return View();
        }
    }
}