using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "ProductPage", GUID = "c5cd9da4-962b-4c23-b9e7-7e813042afd8", Description = "Alloy product page")]
    public class ProductPage : StandardPage
    {
        /* [CultureSpecific]
         [Display(
             Name = "Main body",
             Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
             GroupName = SystemTabNames.Content,
             Order = 1)]
         public virtual XhtmlString MainBody { get; set; }*/

        [Display(
                GroupName = SystemTabNames.Content,
                Order = 305)]
        [UIHint("Textarea")]
        public virtual string UniqueSellingPoints { get; set; }
    }
}