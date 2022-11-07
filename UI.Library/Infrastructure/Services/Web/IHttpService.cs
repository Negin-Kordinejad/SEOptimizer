using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;

namespace UI.Library.Infrastructure.Services.Web
{
    public interface IHttpService
    {
        Task<List<SearchResultDto>> GetSearchGoogleResultAsync(string url, CancellationToken cancellationToken);
    }
}
