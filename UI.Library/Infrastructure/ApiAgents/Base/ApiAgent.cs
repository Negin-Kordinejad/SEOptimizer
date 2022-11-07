using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;
using UI.Library.Infrastructure.Services.Web;

namespace UI.Library.Infrastructure.ApiAgents.Base
{
    public class ApiAgent
    {
        private readonly string _endpoint;
        private readonly IHttpService _httpService;

        public ApiAgent(string endpoint, IHttpService httpService)
        {
            _endpoint = endpoint;
            _httpService = httpService;
        }

        public virtual async Task<List<SearchResultDto>> CallGoogleSearchGetApiAsync(string function, CancellationToken cancellationToken)
        {
            var url = $"{_endpoint}/{function}";
            return await _httpService.GetSearchGoogleResultAsync(url, cancellationToken);
        }


        protected string Query<T>(string query, string name, T value)
        {
            if (value == null)
            {
                return query;
            }

            query = query == string.Empty ? $"?{name}=" : $"{query}&{name}=";

            if (value is DateTime date)
            {
                var val = date.ToString("yyyy-MM-dd'T'HH:mm:ss");
                return $"{query}{val}";

            }

            return $"{query}{value}";
        }

        protected string QueryListInt(string query, string name, ICollection<int> values)
        {
            if (values == null || values.Count == 0)
            {
                return query;
            }

            return values.Aggregate(query, (current, value) => current == string.Empty ? $"?{name}={value}" : $"{current}&{name}={value}");
        }

        protected string FormatNamed(string format, params object[] args)
        {
            var matches = Regex.Matches(format, "{.*?}");

            if (matches.Count < 1)
            {
                return format;
            }

            if (matches.Count != args.Length)
            {
                throw new FormatException($"The given {nameof(format)} does not match the number of {nameof(args)}.");
            }

            for (int i = 0; i < matches.Count; i++)
            {
                format = format.Replace(
                    matches[i].Value,
                    args[i].ToString()
                );
            }

            return format;
        }
    }
}
