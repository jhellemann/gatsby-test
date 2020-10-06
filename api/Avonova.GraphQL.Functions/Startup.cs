using System;
using Avonova.GraphQL.Functions;
using Avonova.GraphQL.Functions.GraphQL;
using Avonova.GraphQL.Functions.HotChocolate.AzureFunctionsMiddleware;
using Avonova.GraphQL.Functions.StarWars.Data;
using Avonova.GraphQL.Functions.StarWars.Types;
using Avonova.GraphQL.Functions.Weather.Repositories;
using Avonova.GraphQL.Functions.Weather.Repositories.Clients;
using Avonova.GraphQL.Functions.Weather.Types;
using HotChocolate;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Avonova.GraphQL.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<CharacterRepository>();
            builder.Services.AddSingleton<ReviewRepository>();
            builder.Services.AddSingleton<WeatherRepository>();

            builder.Services.AddSingleton<Query>();

            builder.Services.AddGraphQL(sp => SchemaBuilder.New()
                .AddServices(sp)
                .AddQueryType<QueryType>()
                .AddType<HumanType>()
                .AddType<DroidType>()
                .AddType<EpisodeType>()
                .AddType<UnitType>()
                .AddType<WeatherType>()
                .Create());

            builder.Services.AddAzureFunctionsGraphQL();

            builder.Services.AddHttpClient<IWeatherRepositoryClient, WeatherRepositoryHttpClient>("WeatherClient",
                client =>
                    client.BaseAddress = new Uri(
                        "https://api.met.no/weatherapi/nowcast/0.9/.json"));
        }
    }
}
