using System;
using System.ComponentModel.DataAnnotations;
using EpiserverSiteWithEmpty.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "NewsPage", GUID = "323b6a49-1f66-47fd-9cf4-7e62aad3bcde", Description = "This text can you have in XML instead")]
    public class NewsPage : StandardPage
    {
        [Display(
                    Name = "Main Listing",
                    Description = "A listing of news pages",
                    GroupName = SystemTabNames.Content,
                    Order = 315)]
        public virtual ListingBlock MainListing { get; set; }

        [Display(
                    Name = "this text can you have in xml instead",
                    Description = "this text can you have in xml instead",
                    GroupName = SystemTabNames.Content,
                    Order = 316)]
        public virtual ContentArea MainContentAreaTest { get; set; }

    }
}