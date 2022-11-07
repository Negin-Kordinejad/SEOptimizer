using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Business.Interface;
using UI.Library.Infrastructure.ApiAgents.SearchApi;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;
using UI.Library.Infrastructure.Services.Base;

namespace UI.Business.Services
{
    public class UrlSearchService : BaseService, IUrlSearchService
    {
        private readonly ILogger<UrlSearchService> _logger;
        private const string CompanyName = "smokeball";
        private const int MinResultSearch = 100;
        private readonly ISearchApiAgent _searchApiAgent;

        public UrlSearchService(ILogger<UrlSearchService> logger, ISearchApiAgent searchApiAgent) : base(logger)
        {
            _logger = logger;
            _searchApiAgent = searchApiAgent;
        }

        /// <summary>
        /// Get the 100 first of our company find in result of Google search.
        /// It gets url from UI as preferring put in a config file so not using this parameter.
        /// </summary>
        public async Task<List<int>> GoogleSearchAsync(string url, string keywords)
        {
            var searchResult =
                await _searchApiAgent.GetGoogleUrlResultAsync(new SearchRequestDto { Keywords = keywords, MinResultNumber = MinResultSearch });
           // _logger.Log( $"{searchResult.Count} ");
            return searchResult.Where(r => r.Title.ToLower().Contains(CompanyName)).Select(s => s.Number).ToList();
        }
    }
}

