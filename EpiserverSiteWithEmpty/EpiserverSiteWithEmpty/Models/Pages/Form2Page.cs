using System.ComponentModel.DataAnnotations;
using EPiBootstrapArea;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "Form2Page", GUID = "FABDB0DA-BA98-4DE2-958D-4A944DBA0D2B", Description = "")]
    public class Form2Page : SitePageData
    {
        [BootstrapRowValidation]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 300)]
        public virtual ContentArea MainContentArea { get; set; }
      
    }
}