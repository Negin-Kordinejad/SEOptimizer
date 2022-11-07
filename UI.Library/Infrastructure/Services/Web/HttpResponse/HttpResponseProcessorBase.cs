using Microsoft.Extensions.Logging;

namespace UI.Library.Infrastructure.Services.Web.HttpResponse
{
    public abstract class HttpResponseProcessorBase
    {
        protected readonly ILogger Logger;

        protected HttpResponseProcessorBase(ILogger logger)
        {
            Logger = logger;
        }
    }
}
