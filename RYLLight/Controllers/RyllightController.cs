using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RYLLight.Models;

namespace RYLLight.Controllers
{
    public abstract class RyllightController : Controller
    {
        // 定义一个表示类型的数组
        public IEnumerable<ProductTypes> types = new List<ProductTypes>
        {
            new ProductTypes
            {
                ProductTypeId = 0,
                ProductTypeName = "商业照明"
            },
            new ProductTypes
            {
                ProductTypeId = 1,
                ProductTypeName = "智能控制"
            },
            new ProductTypes
            {
                ProductTypeId = 2,
                ProductTypeName = "植物照明"
            },
            new ProductTypes
            {
                ProductTypeId = 3,
                ProductTypeName = "水族照明"
            },
            new ProductTypes
            {
                ProductTypeId = 4,
                ProductTypeName = "其它类型"
            }
        };

        // 控制器基类:为了实现往模板页传递数据，比如logo，菜单数据等
        // 数据库上下文
        public RyllightEntities Context { get; set; }

        // 布局页需要用到的数据
        // logo
        public List<Logo> LogoList;

        // menu
        public List<Menu> MenuList;

        public RyllightController()
        {
            // 各种灯具的分类
            ViewBag.Types = types;

            Context = new RyllightEntities();

            // 准备logo数据
            LogoList = new List<Logo>();
            // 获取设置为当前logo的图片：其中Active标记为True的logo
            var logo = from r in Context.Logos
                       where r.Active == true
                       select r;

            // logo只有一个传递第一个
            if (logo.Count() > 0)
            {
                ViewBag.Logo = logo.First<Logo>().PicturePath;
            }else
            {
                // 如果没有取到则提供默认的
                ViewBag.Logo = @"/Images/ledinprologo.png";
            }


            // 准备菜单数据
            MenuList = (from menu in Context.Menus
                        where menu.FreeOne == "Index"
                        orderby menu.Sortnumber ascending
                        select menu).ToList<Menu>();

            if (MenuList.Count > 0)
            {
                // 传递菜单
                ViewBag.MenuList = MenuList;
            }else
            {
                // 提供默认的菜单项
                MenuList.AddRange(
                    new List<Menu>() {
                        /*
                        new Menu {MenuTitle="LIGHTS",Sortnumber=0,Link="Lighting" },
                        new Menu {MenuTitle="APPLICATION",Sortnumber=1,Link="ApplicationScene"},
                        new Menu {MenuTitle="CONTROL",Sortnumber=2,Link="Intellgentcontrol" },
                        new Menu {MenuTitle="HORTICULTURE",Sortnumber=3,Link="Horticulture" },
                        new Menu {MenuTitle="AQUARIUM",Sortnumber=4,Link="Aquarium" },
                        new Menu {MenuTitle="COMPANY",Sortnumber=5,Link="Company" }
                        */
                        new Menu {MenuTitle="News",Sortnumber=0,Link="#companyNews" },
                        new Menu {MenuTitle="Products",Sortnumber=1,Link="#productScenes"},
                        new Menu {MenuTitle="Company",Sortnumber=2,Link="#companyIntroduce" },
                        new Menu {MenuTitle="Contact_Us",Sortnumber=3,Link="#contact" },
                    });
                ViewBag.MenuList = MenuList;
            }

            // 获取业务员数据：需要考虑顺序问题
            var salesContacts = (from sale in Context.SaleContactInfos
                               orderby sale.FreeTwo
                               select sale).ToList<SaleContactInfo>();

            int index = 0;
            if (salesContacts.Count > 0)
            {
                if (int.TryParse(salesContacts[0].FreeTwo, out index))
                {
                    // 如果是不是当天的话，调整顺序
                    DateTime dt;
                    DateTime dtNow = DateTime.Now;
                    if (DateTime.TryParse(salesContacts[0].FreeThree, out dt) == false)
                    {
                        dt = DateTime.Now;
                    }

                    if (index == 0 && (dt.Year != dtNow.Year || dt.Month != dtNow.Month || dt.Day != dtNow.Day))
                    {
                        // 说明顺序需要调整，把业务员信息一次往后移动
                        foreach (var salesContact in salesContacts)
                        {
                            salesContact.FreeThree = DateTime.Now.ToShortDateString();
                            if (index++ == (salesContacts.Count - 1))
                            {
                                salesContact.FreeTwo = 0.ToString();
                            }else
                            {
                                salesContact.FreeTwo = (index).ToString();
                            }
                        }

                        salesContacts = (from sale in Context.SaleContactInfos
                                         orderby sale.FreeTwo
                                         select sale).ToList<SaleContactInfo>();
                    }
                } else
                {
                    foreach (var salesContact in salesContacts)
                    {
                        salesContact.FreeThree = DateTime.Now.ToShortDateString();
                        salesContact.FreeTwo = (index++).ToString();
                    }
                }
            }

            Context.SaveChanges();

            ViewBag.SaleContacts = salesContacts;
        }

        // 获取文件名称
        public string GetDataTimeStr()
        {
            return (DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                        DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() +
                                        DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString());
        }
    }
}