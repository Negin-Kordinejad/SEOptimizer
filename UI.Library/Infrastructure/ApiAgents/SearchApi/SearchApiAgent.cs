using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.Base;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;
using UI.Library.Infrastructure.Config;
using UI.Library.Infrastructure.Services.Web;

namespace UI.Library.Infrastructure.ApiAgents.SearchApi
{
    public class SearchApiAgent : ApiAgent, ISearchApiAgent
    {
        private readonly SearchApiConfig _apiConfig;

        public SearchApiAgent(SearchApiConfig apiConfig, IHttpService httpService)
            : base(apiConfig.Endpoint, httpService)
        {
            _apiConfig = apiConfig;
        }

        public async Task<List<SearchResultDto>> GetGoogleUrlResultAsync(SearchRequestDto googleSearchDto)
        {  
            return await CallGoogleSearchGetApiAsync($"{_apiConfig.GoogleSearchUrl}?num={googleSearchDto.MinResultNumber}&q={googleSearchDto.Keywords}",
              CancellationToken.None);
        }
    }
}
