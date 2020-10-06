using System;
using System.Collections.Generic;

namespace Avonova.GraphQL.Functions.Weather.Repositories.Models
{
    public class WeatherResponse
    {
        public Product Product { get; set; }
    }

    public class Product
    {
        public List<Time> Time { get; set; }
    }

    public class Time
    {
        public DateTimeOffset To { get; set; }
        public DateTimeOffset From { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Precipitation Precipitation { get; set; }
    }

    public class Precipitation
    {
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}