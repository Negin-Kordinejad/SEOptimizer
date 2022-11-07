using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;

namespace UI.Library.Infrastructure.Services.Web.HttpResponse
{
    public class HttpNotFoundResponseProcessor : HttpResponseProcessorBase, IHttpResponseProcessor
    {

        public HttpNotFoundResponseProcessor(ILogger logger) : base(logger)
        {

        }
        
        public async Task<List<SearchResultDto>> ProcessGoogleSearchAsync(HttpResponseMessage httpResponse, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            // Logger.Info(() => $"HttpNotFoundResponseProcessor.ProcessAsync");
            var t = new List<SearchResultDto>();
            return t;
        }
    }
}
