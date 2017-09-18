using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace RYLLight.ToolsClass
{
    public static class ImageActionLinkHelper
    {
        // 扩展ActionLink方法:使其可以在链接中显示图片
        // 扩展方法的写法：使用this加要扩展的类型，即扩展方法的第一个参数
        public static IHtmlString ImageActionLink(this AjaxHelper helper, string imageUrl, string linkTitle, 
            string altText, string actionName, object routesValues, AjaxOptions ajaxOptions,
            object htmlAttributes = null)
        {
            // 创建一个img标签
            var imgBuilder = new TagBuilder("img");

            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.MergeAttribute("class", "img-responsive");

            var spanBuilder = new TagBuilder("span")
            {
                InnerHtml = linkTitle
            };

            MvcHtmlString link = helper.ActionLink("[replaceme]", actionName, routesValues, ajaxOptions, htmlAttributes);

            return MvcHtmlString.Create(link.ToString().Replace("[replaceme]", imgBuilder.ToString(TagRenderMode.SelfClosing) + spanBuilder.ToString(TagRenderMode.Normal)));
        }
    }
}