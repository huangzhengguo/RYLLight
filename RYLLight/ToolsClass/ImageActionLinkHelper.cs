using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace RYLLight.ToolsClass
{
    public static class ImageActionLinkHelper
    {
        // 扩展方法的写法：使用this加要扩展的类型，即扩展方法的第一个参数

        /// <summary>
        /// 生成底部带有文字的图片超链接
        /// </summary>
        /// <param name="imageUrl">图片链接</param>
        /// <param name="linkTitle">底部文字</param>
        /// <param name="altText">替代文字</param>
        /// <param name="actionName">方法名称</param>
        /// <param name="routesValues">路由值</param>
        /// <param name="ajaxOptions">ajax选项</param>
        /// <param name="htmlAttributes">html属性</param>
        /// <returns>超链接对象</returns>
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

            return MvcHtmlString.Create(link.ToString().Replace("[replaceme]", 
                imgBuilder.ToString(TagRenderMode.SelfClosing) + spanBuilder.ToString(TagRenderMode.Normal)));
        }
    }
}