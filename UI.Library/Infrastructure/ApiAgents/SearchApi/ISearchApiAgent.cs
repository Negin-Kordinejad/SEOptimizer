using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;

namespace UI.Library.Infrastructure.ApiAgents.SearchApi
{
    public interface ISearchApiAgent
    {
        Task<List<SearchResultDto>> GetGoogleUrlResultAsync(SearchRequestDto googleSearchDto);
    }
}
