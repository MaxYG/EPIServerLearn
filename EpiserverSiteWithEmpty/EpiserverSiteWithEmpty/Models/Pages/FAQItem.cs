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