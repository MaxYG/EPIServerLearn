using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "ProductPage", GUID = "c5cd9da4-962b-4c23-b9e7-7e813042afd8", Description = "Alloy product page")]
    public class ProductPage : StandardPage
    {
        [Display(
                GroupName = SystemTabNames.Content,
                Order = 305)]
        [UIHint("Textarea")]
        public virtual string UniqueSellingPoints { get; set; }

        [Display(
                GroupName = SystemTabNames.Content,
                Order = 320)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
                GroupName = SystemTabNames.Content,
                Order = 330)]
        public virtual ContentArea RelatedContentArea { get; set; }


    }
}