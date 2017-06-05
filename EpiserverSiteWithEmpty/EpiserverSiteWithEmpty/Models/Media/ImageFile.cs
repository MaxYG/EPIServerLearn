using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "483a4f58-82fd-4e7f-95dd-8c50f7fd920a", Description = "")]
    /*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]
      ImageData instead of MediaData
         */
    public class ImageFile : ImageData
    {
               /* [CultureSpecific]
                [Editable(true)]
                [Display(
                    Name = "Description",
                    Description = "Description field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]*/
                public virtual string Description { get; set; }
    }
}