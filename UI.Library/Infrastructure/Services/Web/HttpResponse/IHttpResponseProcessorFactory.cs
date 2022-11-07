using System.Net;

namespace UI.Library.Infrastructure.Services.Web.HttpResponse
{
    public interface IHttpResponseProcessorFactory
    {
        IHttpResponseProcessor GetHttpResponseProcessor(HttpStatusCode statusCode);
    }
}
