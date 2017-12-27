using IdentityModel;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace testingApp
{
    public class Program
    {
        static TokenClient _tokenClient;

        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            Console.Title = "Console ResourceOwner Flow RefreshToken";

            //var disco = await DiscoveryClient.GetAsync(Constants.Authority);
            //if (disco.IsError) throw new Exception(disco.Error);

            _tokenClient = new TokenClient("http://djridesauth20171227094924.azurewebsites.net/connect/token", "client", "secret");

            var response = await RequestTokenAsync();
            Console.WriteLine(response.Json);
            //response.Show();

            Console.ReadLine();

            var refresh_token = response.RefreshToken;

            var somecall = CallServiceAsync(response.AccessToken);

            while (true)
            {
                response = await RefreshTokenAsync(refresh_token);
                ShowResponse(response);

                Console.ReadLine();
                await CallServiceAsync(response.AccessToken);

                if (response.RefreshToken != refresh_token)
                {
                    refresh_token = response.RefreshToken;
                }
            }
        }

        static async Task<TokenResponse> RequestTokenAsync()
        {
            return await _tokenClient.RequestResourceOwnerPasswordAsync(
                "safikmomin@hotmail.com",
                "Bluepanther12!",
                "MainApi1 offline_access profile openid");
        }

        private static async Task<TokenResponse> RefreshTokenAsync(string refreshToken)
        {
            Console.WriteLine("Using refresh token: {0}", refreshToken);

            return await _tokenClient.RequestRefreshTokenAsync(refreshToken);
        }

        static async Task CallServiceAsync(string token)
        {
            var baseAddress = "http://localhost:63285";

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            client.SetBearerToken(token);
            var response = await client.GetStringAsync("/api/values");
            
            Console.WriteLine(JArray.Parse(response));
        }

        private static void ShowResponse(TokenResponse response)
        {
            if (!response.IsError)
            {
                Console.WriteLine(response.Json);

                if (response.AccessToken.Contains("."))
                {

                    var parts = response.AccessToken.Split('.');
                    var header = parts[0];
                    var claims = parts[1];

                    Console.WriteLine(JObject.Parse(Encoding.UTF8.GetString(Base64Url.Decode(header))));
                    Console.WriteLine(JObject.Parse(Encoding.UTF8.GetString(Base64Url.Decode(claims))));
                }
            }
            else
            {
                if (response.ErrorType == ResponseErrorType.Http)
                {
                    Console.WriteLine(response.Error);
                    Console.WriteLine(response.HttpStatusCode);
                }
                else
                {
                    Console.WriteLine(response.Json);
                }
            }
        }
    }
}
