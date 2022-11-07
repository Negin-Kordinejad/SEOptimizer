using Microsoft.Extensions.Logging;

namespace UI.Library.Infrastructure.Services.Base
{
    public class BaseService
    {
        protected readonly ILogger _log;

        public BaseService(ILogger log)
        {
            _log = log;
        }
       
        public virtual void Log(string msg)
        {
            _log.LogInformation(msg);
        }
    }
}
