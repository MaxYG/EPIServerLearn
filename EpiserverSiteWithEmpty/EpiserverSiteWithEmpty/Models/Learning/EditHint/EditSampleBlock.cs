using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EpiserverSiteWithEmpty.Models.Learning.EditHint
{
    //http://world.episerver.com/documentation/Items/Developers-Guide/Episerver-CMS/9/Content/Edit-hints-in-MVC/
    //    [ContentType(DisplayName = "EditSampleBlock", GUID = "95ff3104-c20b-4e99-91ff-7e70b5d9f0a6", Description = "")]
    [ContentType]
    public class EditSampleBlock : BlockData
    {
        public virtual string Heading { get; set; }
        public virtual XhtmlString Body { get; set; }
    }
}