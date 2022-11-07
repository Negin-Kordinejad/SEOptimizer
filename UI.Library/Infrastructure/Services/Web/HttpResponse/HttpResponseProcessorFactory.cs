using Microsoft.Extensions.Logging;
using System.Net;

namespace UI.Library.Infrastructure.Services.Web.HttpResponse
{
    public class HttpResponseProcessorFactory : IHttpResponseProcessorFactory
    {
        private readonly ILogger _logger;

        public HttpResponseProcessorFactory(ILogger<HttpResponseProcessorFactory> logger)
        {
            _logger = logger;
        }

        public IHttpResponseProcessor GetHttpResponseProcessor(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    return new HttpOkResponseProcessor(_logger);
               
                case HttpStatusCode.NotFound:
                    return new HttpNotFoundResponseProcessor(_logger);
                default:
                    return new HttpNotFoundResponseProcessor(_logger);
            }

        }
    }
}
