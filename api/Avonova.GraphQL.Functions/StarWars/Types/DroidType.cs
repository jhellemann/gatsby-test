using Avonova.GraphQL.Functions.StarWars.Models;
using Avonova.GraphQL.Functions.StarWars.Resolvers;
using HotChocolate.Types;

namespace Avonova.GraphQL.Functions.StarWars.Types
{
    public class DroidType
        : ObjectType<Droid>
    {
        protected override void Configure(IObjectTypeDescriptor<Droid> descriptor)
        {
            descriptor.Interface<CharacterType>();

            descriptor.Field(t => t.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.AppearsIn)
                .Type<ListType<EpisodeType>>();

            descriptor.Field<SharedResolvers>(r => r.GetCharacter(default, default))
                .Type<ListType<CharacterType>>()
                .Name("friends");

            descriptor.Field<SharedResolvers>(t => t.GetHeight(default, default))
                .Type<FloatType>()
                .Argument("unit", a => a.Type<UnitType>())
                .Name("height");
        }
    }
}
