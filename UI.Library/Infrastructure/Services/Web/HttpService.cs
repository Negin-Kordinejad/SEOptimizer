using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;
using UI.Library.Infrastructure.Services.Web.HttpResponse;

namespace UI.Library.Infrastructure.Services.Web
{
    public class HttpService : IHttpService
    {
        private readonly ILogger<HttpService>  _logger;
        private readonly IHttpResponseProcessorFactory _httpResponseProcessorFactory;

        private const string TimeOut = "API request timed out";

        public HttpService(ILogger<HttpService> logger, IHttpResponseProcessorFactory httpResponseProcessorFactory)
        {
            _logger = logger;
            _httpResponseProcessorFactory = httpResponseProcessorFactory;
        }

        public async Task<List<SearchResultDto>> GetSearchGoogleResultAsync(string url, CancellationToken cancellationToken)
        {
            // _logger.log(() => $"GetSearchGoogleResultAsync({url})");
            using (var client = new HttpClient())
            {
                try
                {
                    CreateSecurityHeader(client);

                    var httpResponse = await client.GetAsync(url, cancellationToken);
                    var responseProcessor =
                        _httpResponseProcessorFactory.GetHttpResponseProcessor(httpResponse.StatusCode);

                    return await responseProcessor.ProcessGoogleSearchAsync(httpResponse, cancellationToken);
                }
                catch (TaskCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    // _logger.LogError(() => "HttpService.GetSearchGoogleResultAsync cancellation requested");
                    return new List<SearchResultDto>();
                }
                catch (TaskCanceledException)
                {
                    var timeoutException = new Exception(TimeOut);
                    // _logger.LogError(() => "HttpService.GetSearchGoogleResultAsync task cancelled", timeoutException);
                    throw timeoutException;
                }
                catch (Exception e)
                {
                    //_logger.LogError(()=> "HttpService.GetSearchGoogleResultAsync", e);
                    throw;
                }
            }
        }

        private void CreateSecurityHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("Accept", "text/html");
        }
    }
}
