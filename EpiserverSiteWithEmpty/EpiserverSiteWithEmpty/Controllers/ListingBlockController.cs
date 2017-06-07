using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Blocks;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class ListingBlockController : BlockController<ListingBlock>
    {
        public override ActionResult Index(ListingBlock currentBlock)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var model = new ListingBlockModel
            {
                Heading = currentBlock.Heading,
                Items = currentBlock.RootPage != null
                    ? contentRepository.GetChildren<PageData>(currentBlock.RootPage)
                    : null
            };
            return PartialView(model);
        }
    }
}
