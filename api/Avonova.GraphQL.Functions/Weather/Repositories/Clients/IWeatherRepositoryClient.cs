using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avonova.GraphQL.Functions.Weather.Repositories.Clients
{
    public interface IWeatherRepositoryClient
    {
        Task<HttpResponseMessage> Get(Uri uri);
    }
}