using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "FormProductPage", GUID = "95DF2385-4DEF-41BA-BA41-DC26C50EE2DB", Description = "forms page")]
    public class FormsPage : StandardPage
    {
     
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 320)]
        public virtual ContentArea FormsContentArea { get; set; }

        
    }
}