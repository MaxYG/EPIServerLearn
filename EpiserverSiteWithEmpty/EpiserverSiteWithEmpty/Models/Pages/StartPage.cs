using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EpiserverSiteWithEmpty.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "313d6546-f5f9-4b03-ae1a-bae427e7477f", Description = "")]
    public class StartPage : SitePageData
    {
            [CultureSpecific]
            [Display(
                Name = "Main body",
                Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
                GroupName = SystemTabNames.Content,
                Order = 1)]
            public virtual XhtmlString MainBody { get; set; }

        [Display(
                GroupName = SystemTabNames.Content,
                Order = 0)]
        public virtual string Heading { get; set; }


        [Display(
                GroupName = SystemTabNames.Content,
                Order = 300)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(GroupName = SystemTabNames.Content)]
        public virtual PageReference SearchPageLink { get; set; }


    }
}