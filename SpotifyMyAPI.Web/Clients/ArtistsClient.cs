using System.Threading.Tasks;
using SpotifyMyAPI.Web.Http;
using URLs = SpotifyMyAPI.Web.SpotifyUrls;

namespace SpotifyMyAPI.Web
{
    public class ArtistsClient : APIClient, IArtistsClient
    {
        public ArtistsClient(IAPIConnector apiConnector) : base(apiConnector) { }

        public Task<FullArtist> Get(string artistId)
        {
            Ensure.ArgumentNotNullOrEmptyString(artistId, nameof(artistId));

            return API.Get<FullArtist>(URLs.Artist(artistId));
        }

        public Task<ArtistsResponse> GetSeveral(ArtistsRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return API.Get<ArtistsResponse>(URLs.Artists(), request.BuildQueryParams());
        }
    }
}