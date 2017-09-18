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
        // 控制器基类:为了实现往模板页传递数据，比如logo，菜单数据等
        // 数据库上下文
        public RyllightEntities context { get; set; }

        // 布局页需要用到的数据
        // logo
        public List<Logo> LogoList;

        // menu
        public List<Menu> MenuList;

        public RyllightController()
        {
            context = new RyllightEntities();

            // 准备logo数据
            LogoList = new List<Logo>();
            // 获取设置为当前logo的图片：其中Active标记为True的logo
            var logo = from r in context.Logos
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
            MenuList = (from menu in context.Menus
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