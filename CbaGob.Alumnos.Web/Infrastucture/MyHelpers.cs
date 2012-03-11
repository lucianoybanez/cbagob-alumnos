using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CbaGob.Alumnos.Web.Infrastucture
{
    public static class MyHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper html, string imageName, object htmlAttributes=null)
        {
            var tag = new TagBuilder("img");
            UrlHelper myUrl = new UrlHelper(html.ViewContext.RequestContext);
            string route = myUrl.Content("~/Content/images/" + imageName);
            tag.MergeAttribute("src", route);
            if (htmlAttributes!=null)
            {
                tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        public static string ToFecha(this DateTime? date)
        {
            if (date == null)
            {
                return "";
            }
            return String.Format("{0:dd/MM/yyyy}", date);
        }

        public static string ToFecha(this DateTime date)
        {
            return String.Format("{0:dd/MM/yyyy}", date);
        }
    }
}