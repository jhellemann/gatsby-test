using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avonova.GraphQL.Functions.Weather.Repositories.Clients
{
    public class WeatherRepositoryHttpClient : IWeatherRepositoryClient
    {
        private readonly HttpClient _client;

        public WeatherRepositoryHttpClient(HttpClient client)
        {
            _client = client;
        }

        public Task<HttpResponseMessage> Get(Uri uri) => _client.GetAsync(uri);
    }
}