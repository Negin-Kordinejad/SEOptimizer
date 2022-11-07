using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;

namespace UI.Library.Infrastructure.Services.Web.HttpResponse
{
    public interface IHttpResponseProcessor
    {
        Task<List<SearchResultDto>> ProcessGoogleSearchAsync(HttpResponseMessage httpResponse,
            CancellationToken cancellationToken);
    }
}
