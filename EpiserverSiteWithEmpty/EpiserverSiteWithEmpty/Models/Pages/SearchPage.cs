using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "SearchPage", GUID = "92c544b5-f556-4ca6-9e9e-a8b930c3bbe2", Description = "")]
    public class SearchPage : SitePageData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
         */
    }
}