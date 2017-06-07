using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Blocks;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class TeaserBlockController : BlockController<TeaserBlock>
    {
        public override ActionResult Index(TeaserBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
