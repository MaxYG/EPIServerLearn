using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Blocks
{
    [ContentType(DisplayName = "EditorialBlock", GUID = "f10f2ecc-466c-4ef2-bb27-b8a45c9870ff", Description = "")]
    public class EditorialBlock : BlockData
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
        [Display(
                    Name = "Block main body",
                    Description = "Block main body description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
        public virtual XhtmlString MainBody { get; set; }
    }
}