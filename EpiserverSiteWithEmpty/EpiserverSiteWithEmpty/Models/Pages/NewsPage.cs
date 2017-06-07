using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSiteWithEmpty.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "NewsPage", GUID = "323b6a49-1f66-47fd-9cf4-7e62aad3bcde", Description = "")]
    public class NewsPage : StandardPage
    {
                /*[CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }*/

        [Display(
                    Name = "Main Listing",
                    Description = "A listing of news pages",
                    GroupName = SystemTabNames.Content,
                    Order = 315)]
        public virtual ListingBlock MainListing { get; set; }
    }
}