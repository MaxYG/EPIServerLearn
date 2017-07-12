

using System.ComponentModel.DataAnnotations;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Learning.Personalization
{
    [ContentType]
    public class PersonalizationVisitorGroups: SitePageData
    {
    
        [Display(
                Name = "Personalization Visitor Group",
                GroupName = SystemTabNames.Content,
                Order = 1)]
        public virtual XhtmlString PersonalizationVisitorGroup { get; set; }
    }
}