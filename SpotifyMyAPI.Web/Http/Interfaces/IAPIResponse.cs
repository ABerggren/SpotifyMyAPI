namespace SpotifyMyAPI.Web.Http
{
    public interface IAPIResponse<out T>
    {
        T Body { get; }

        IResponse Response { get; }
    }
}