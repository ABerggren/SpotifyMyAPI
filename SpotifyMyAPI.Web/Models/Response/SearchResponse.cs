namespace SpotifyMyAPI.Web
{
    public class SearchResponse
    {
        public Paging<FullArtist, SearchResponse> Artists { get; set; } = default!;
    }
}
