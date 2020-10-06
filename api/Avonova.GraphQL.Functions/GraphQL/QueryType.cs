using Avonova.GraphQL.Functions.StarWars.Models;
using Avonova.GraphQL.Functions.StarWars.Types;
using Avonova.GraphQL.Functions.Weather.Types;
using HotChocolate.Types;

namespace Avonova.GraphQL.Functions.GraphQL
{
    public class QueryType
        : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetHero(default))
                .Type<CharacterType>()
                .Argument("episode", a => a.DefaultValue(Episode.NewHope));

            descriptor.Field(t => t.GetCharacter(default, default))
                .Type<NonNullType<ListType<NonNullType<CharacterType>>>>()
                .Argument("characterIds",
                    a => a.Type<NonNullType<ListType<NonNullType<IdType>>>>());

            descriptor.Field(t => t.GetCharacters())
                .Name("characters")
                .Type<ListType<CharacterType>>();

            descriptor.Field(t => t.GetHuman(default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());

            descriptor.Field(t => t.GetDroid(default))
                .Argument("id", a => a.Type<NonNullType<IdType>>());

            descriptor.Field(t => t.GetWeather(default, default))
                .Type<WeatherType>()
                .Argument("longitude", a => a.DefaultValue(10.716667))
                .Argument("latitude", a => a.DefaultValue(59.933333));
        }
    }

}
