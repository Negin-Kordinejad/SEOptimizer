using System.Collections.Generic;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;

namespace UI.Library.Infrastructure.Services.Helper
{
    public static class HtmlHelper
    {
        /// <summary>
        /// This helper doesn't work, just for test
        /// </summary>
        public static List<SearchResultDto> GetSearchGoogleHtmlResult(string htmlDocument)
        {
            var links = GetSearchGoogleHtmlLinks(htmlDocument);
            var searchResultDtos = new List<SearchResultDto>();
            foreach (var link in links)
            {
                searchResultDtos.Add(new SearchResultDto { Title = link, Number = links.IndexOf(link)+1 });
            }

            return searchResultDtos;
        }

        private static List<string> GetSearchGoogleHtmlLinks(string htmlDocument)
        {
            return new List<string> { "www.smokeball.com.au", "", "" , "the company is www.smokeball.com.au" };
        }

    }
}
