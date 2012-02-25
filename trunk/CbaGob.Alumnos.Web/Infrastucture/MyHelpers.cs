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
    }
}