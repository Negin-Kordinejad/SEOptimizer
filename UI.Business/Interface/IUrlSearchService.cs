using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs;


namespace UI.Business.Interface
{
    public interface IUrlSearchService
    {
        Task<List<int>> GoogleSearchAsync(string url, string keywords);
    }
}
