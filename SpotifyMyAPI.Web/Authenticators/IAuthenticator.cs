using System.Threading.Tasks;
using SpotifyMyAPI.Web.Http;

namespace SpotifyMyAPI.Web
{
    public interface IAuthenticator
    {
        Task Apply(IRequest request, IAPIConnector apiConnector);
    }
}
