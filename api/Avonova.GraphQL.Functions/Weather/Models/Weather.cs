using System;

namespace Avonova.GraphQL.Functions.Weather.Models
{
    public class Weather
    {
        public DateTimeOffset Date { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
    }
}