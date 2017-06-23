using System.Web;
using System.Web.Mvc;

namespace EpiserverSiteWithEmpty.Commons
{
    public static class EpiProvider
    {
        public static IHtmlString ToLineBreakString(this string original)
        {
            var parsed = string.Empty;
            if (!string.IsNullOrEmpty(original))
            {
                parsed = HttpUtility.HtmlEncode(original);
                parsed = parsed.Replace("\n", "<br />");
            }

            return new MvcHtmlString(parsed);
        }
    }
}