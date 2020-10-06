using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Avonova.GraphQL.Functions.Weather.Extensions
{
    public static class HttpClientExtensions
    {
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static async Task<T> ReadAs<T>(this HttpResponseMessage response)
        {
            if (response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseContent, Options);
        }
    }
}