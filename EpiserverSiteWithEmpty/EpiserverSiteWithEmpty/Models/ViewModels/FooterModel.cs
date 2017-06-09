using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;


namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public class FooterModel
    {
        public bool LoggedIn { get; set; }
        public PageDataCollection ProductPages { get; set; }
        public string LoginUrl { get; set; }

        public FooterModel(SitePageData currentPage)
        {
            this.LoginUrl = GetLoginUrl(currentPage.ContentLink);
            this.LoggedIn = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            RetrieveSiteProductPages();
        }

        private void RetrieveSiteProductPages()
        {
            PropertyCriteriaCollection criteria = new PropertyCriteriaCollection();

            PropertyCriteria prodpagecriterion = new PropertyCriteria();
            prodpagecriterion.Condition = CompareCondition.Equal;
            prodpagecriterion.Name = "PageTypeID";
            prodpagecriterion.Type = PropertyDataType.PageType;

            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            prodpagecriterion.Value = contentTypeRepository.Load("ProductPage").ID.ToString();
            prodpagecriterion.Required = true;
            criteria.Add(prodpagecriterion);

            ProductPages = DataFactory.Instance.FindPagesWithCriteria(PageReference.StartPage, criteria);
        }

        private string GetLoginUrl(ContentReference returnToContentLink)
        {
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var returnUrl = urlResolver.GetUrl(returnToContentLink);
            return returnUrl;
        }

       
    }
}