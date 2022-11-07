namespace UI.Library.Infrastructure.ApiAgents.SearchApi.DTOs
{
    public class SearchRequestDto
    {
        public int MinResultNumber { get; set; }
        public string Keywords { get; set; }
        public string Url { get; set; }
    }
}
