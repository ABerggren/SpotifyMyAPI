using System.Threading.Tasks;

namespace SpotifyMyAPI.Web
{
    /// <summary>
    /// Endpoints for retrieving information about one or more artists from the Spotify catalog.
    /// </summary>
    public interface IArtistsClient
    {
        /// <summary>
        /// Get Spotify catalog information for several artists based on their Spotify IDs.
        /// </summary>
        /// <remarks>
        /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-multiple-artists
        /// </remarks>
        /// <param name="request">The request-model which contains required and optional parameters</param>
        /// <returns></returns>
        Task<ArtistsResponse> GetSeveral(ArtistsRequest request);

        /// <summary>
        /// Get Spotify catalog information for a single artist identified by their unique Spotify ID.
        /// </summary>
        /// <param name="artistId">The Spotify ID of the artist.</param>
        /// <remarks>
        /// https://developer.spotify.com/documentation/web-api/reference-beta/#endpoint-get-an-artist
        /// </remarks>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716")]
        Task<FullArtist> Get(string artistId);
    }
}