using System.Threading.Tasks;
using SpotifyMyAPI.Web.Http;
using URLs = SpotifyMyAPI.Web.SpotifyUrls;

namespace SpotifyMyAPI.Web
{
    public class SearchClient : APIClient, ISearchClient
    {
        public SearchClient(IAPIConnector apiConnector) : base(apiConnector) { }

        public Task<SearchResponse> Item(SearchRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return API.Get<SearchResponse>(URLs.Search(), request.BuildQueryParams());
        }
    }
}
