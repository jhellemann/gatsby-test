using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Avonova.GraphQL.Functions.Weather.Extensions;
using Avonova.GraphQL.Functions.Weather.Repositories.Clients;

namespace Avonova.GraphQL.Functions.Weather.Repositories
{
    public class WeatherRepository
    {
        private readonly IWeatherRepositoryClient _weatherRepositoryClient;

        public WeatherRepository(IWeatherRepositoryClient weatherRepositoryClient)
        {
            _weatherRepositoryClient = weatherRepositoryClient;
        }

        private async Task<Models.WeatherResponse> GetWeatherFromRepository(double latitude, double longitude)
        {
            var weatherResult = await _weatherRepositoryClient.Get(
                new Uri(
                    $"?lat={latitude.ToString("0.00000", CultureInfo.InvariantCulture)}&lon={longitude.ToString("0.00000", CultureInfo.InvariantCulture)}",
                    UriKind.Relative));

            if (!weatherResult.IsSuccessStatusCode)
            {
                return null;
            }

            return await weatherResult.ReadAs<Models.WeatherResponse>();
        }

        public async Task<Weather.Models.Weather> GetWeather(double latitude, double longitude)
        {
            var weatherResult = await GetWeatherFromRepository(latitude, longitude);

            if (weatherResult is null)
            {
                return new Weather.Models.Weather();
            }

            var first = weatherResult.Product.Time.First();

            var isLatitude = double.TryParse(first.Location.Latitude, NumberStyles.Any, CultureInfo.InvariantCulture, out var lat);
            var isLongitude = double.TryParse(first.Location.Longitude, NumberStyles.Any, CultureInfo.InvariantCulture, out var lon);

            var sum = weatherResult.Product.Time.Sum(v =>
                double.TryParse(v.Location.Precipitation.Value, NumberStyles.Any, CultureInfo.InvariantCulture,
                    out var value)
                    ? value
                    : 0);

            return new Functions.Weather.Models.Weather
            {
                Latitude = isLatitude ? lat : 0,
                Longitude = isLongitude ? lon : 0,
                Date = first.From.Date,
                Unit = first.Location.Precipitation.Unit,
                Value = sum
            };
        }
    }
}