using System.Linq;
using System.Web.Mvc;
using EpiserverSiteWithEmpty.Models.Pages;
using EpiserverSiteWithEmpty.Models.ViewModels;
using EPiServer;
using EPiServer.DataAccess;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;

namespace EpiserverSiteWithEmpty.Controllers
{
    public class FAQPageController : PageControllerBase<FAQPage>
    {
        public ActionResult Index(FAQPage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            currentPage.FAQItems = contentRepository.GetChildren<FAQItem>(currentPage.ContentLink).ToList();
            var model=new DefaultPageViewModel<FAQPage>(currentPage);
            return View(model);
        }

        public ActionResult Submit(FAQPage currentPage, string question)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var faqItem = contentRepository.GetDefault<FAQItem>(currentPage.ContentLink);
            faqItem.Name = string.Format("Question:{0}", question);
            faqItem.Question = question;
            contentRepository.Save(faqItem, EPiServer.DataAccess.SaveAction.Save,EPiServer.Security.AccessLevel.Read);
            var model=new DefaultPageViewModel<FAQPage>(currentPage);

            return View("Index", model);
        }
    }
}