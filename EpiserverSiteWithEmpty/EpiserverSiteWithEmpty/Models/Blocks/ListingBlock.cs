using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Blocks
{
    [ContentType(DisplayName = "ListingBlock", GUID = "a1b15243-80d5-42d5-bbb7-17d25b49b9ff", Description = "")]
    public class ListingBlock : BlockData
    {
        /*
                [CultureSpecific]
                [Display(
                    Name = "Name",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual string Name { get; set; }
         */

        [Display(
                    Name = "Heading",
                    Description = "listing block heading",
                    GroupName = SystemTabNames.Content,
                    Order = 100)]
        public virtual string Heading { get; set; }

        [Display(
                   Name = "RootPage",
                   Description = "listing block rootpage",
                   GroupName = SystemTabNames.Content,
                   Order = 200)]
        public virtual PageReference RootPage { get; set; }
    }
}