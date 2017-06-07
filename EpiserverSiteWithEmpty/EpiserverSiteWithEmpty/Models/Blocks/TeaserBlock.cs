using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Blocks
{
    [ContentType(DisplayName = "TeaserBlockType", GUID = "996a9036-98cd-4445-ad33-8a50f606a8c6", Description = "")]
    public class TeaserBlock : BlockData
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

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content,Order = 100)]
        [UIHint("Image")]
        public virtual ContentReference TeaserImage { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual string TeaserHeading { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 300)]
        [UIHint("Textarea")]
        public virtual string TeaserText { get; set; }

        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content, Order = 400)]
        public virtual PageReference TeaserLink { get; set; }
    }
}