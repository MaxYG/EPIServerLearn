using System.Collections.Generic;
using System.Linq;
using EpiserverSiteWithEmpty.Models.Pages;
using EPiServer.Globalization;
using EPiServer.Search;

namespace EpiserverSiteWithEmpty.Models.ViewModels
{
    public class SearchPageViewModel :IPageViewModel<SearchPage>
    {
        public SearchPageViewModel(SearchPage currentPage)
        {
            this.CurrentPage = currentPage;
        }

        public SearchPage CurrentPage { get; set; }
        public string SearchText { get; set; }
        public List<IndexResponseItem> SearchResult { get; set; }

        public void Search(string q)
        {
            var culture = ContentLanguage.PreferredCulture.Name;
            this.SearchResult=new List<IndexResponseItem>();
            var fieldQuery=new EPiServer.Search.Queries.Lucene.FieldQuery(q);

            var fieldQueryResult =
                SearchHandler.Instance.GetSearchResults(fieldQuery, 1, 40)
                    .IndexResponseItems.Where(x => x.Culture.Equals(culture) || string.IsNullOrEmpty(x.Culture))
                    .ToList();
            SearchResult.AddRange(fieldQueryResult);
        }
    }
}