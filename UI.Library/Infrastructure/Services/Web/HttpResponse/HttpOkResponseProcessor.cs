using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;
using UI.Library.Infrastructure.Services.Helper;

namespace UI.Library.Infrastructure.Services.Web.HttpResponse
{
    public class HttpOkResponseProcessor : HttpResponseProcessorBase, IHttpResponseProcessor
    {

        public HttpOkResponseProcessor(ILogger logger) : base(logger)
        {

        }

        public async Task<List<SearchResultDto>> ProcessGoogleSearchAsync(HttpResponseMessage httpResponse, CancellationToken cancellationToken)
        {
            //const string loggerMessagePrefix = "OkResponseProcessor.ProcessAsync:";
            try
            {
                var stringResult = await httpResponse.Content.ReadAsStringAsync();
               
                return HtmlHelper.GetSearchGoogleHtmlResult(stringResult);

            }
            catch (Exception e)
            {
                //  Logger.log(() => $"{loggerMessagePrefix}", e);
                throw;
            }
        }
    }
}
