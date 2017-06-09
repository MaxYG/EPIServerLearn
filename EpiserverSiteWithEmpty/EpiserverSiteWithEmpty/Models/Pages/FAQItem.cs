using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "FAQItem", 
        GUID = "fd3a8601-3bc5-4bdc-950e-4b560e1baa0d", 
        AvailableInEditMode = false,
        Description = "")]
    public class FAQItem : SitePageData
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
        [Display(
                   GroupName = SystemTabNames.Content,
                   Order = 10)]
        public virtual string Question { get; set; }

        [Display(
                 GroupName = SystemTabNames.Content,
                 Order = 20)]
        public virtual XhtmlString Answer { get; set; }
    }
}