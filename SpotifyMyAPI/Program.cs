using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SpotifyMyAPI.Web;

namespace SpotifyMyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your ClientID: ");

            var spotifyClient = Console.ReadLine();

            Console.Write("Enter Client Secret: ");

            var spotifySecret = Console.ReadLine();

            var webClient = new WebClient();

            var postparams = new NameValueCollection();
            postparams.Add("grant_type", "client_credentials");

            var authHeader = Convert.ToBase64String(Encoding.Default.GetBytes($"{spotifyClient}:{spotifySecret}"));
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);
            try
            {
                var tokenResponse = webClient.UploadValues("https://accounts.spotify.com/api/token", postparams);
                var TokenRes = Encoding.UTF8.GetString(tokenResponse);

                int pFrom = TokenRes.IndexOf("access_token") + "access_token".Length;
                int pTo = TokenRes.LastIndexOf("token_type");
                string semiToken = TokenRes.Substring(pFrom, pTo - pFrom);
                string myAccessToken = semiToken.Substring(3, semiToken.Length - 6);

                Console.WriteLine("press E to exit, enter to continue...");

                while (Console.ReadKey().Key != ConsoleKey.E)
                {
                    Console.Write("Enter artists name: ");
                    var name = Console.ReadLine();
                    if (name != null && name != string.Empty)
                    {
                        SearchRequest search = new SearchRequest(SearchRequest.Types.Artist, name);
                        var task = Search(myAccessToken, search);
                        task.Wait();
                    }
                    Console.WriteLine("press E to exit, enter to continue...");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task Search(string myAccessToken, SearchRequest search)
        {
            var spotify = new SpotifyClient(myAccessToken);
            var artist = await spotify.Search.Item(search);
            bool artistFound = false;

            for (int i = 0; i < artist.Artists.Items.Count; i++)
            {
                if (artist.Artists.Items[i].Name.ToLower().Replace(".", "").Replace(" ", "") == Regex.Replace(search.Query, @"[^0-9a-zA-Z]+", "").ToLower())
                {
                    Console.WriteLine(artist.Artists.Items[i].Id + " - " + artist.Artists.Items[i].Name);
                    artistFound = true;
                }

                if (!artistFound)
                {
                    Console.WriteLine("Artist Not Found!");
                }
            }
        }
    }
}
