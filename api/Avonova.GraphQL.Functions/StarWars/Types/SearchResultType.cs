using Avonova.GraphQL.Functions.StarWars.Models;
using HotChocolate.Types;

namespace Avonova.GraphQL.Functions.StarWars.Types
{
    public class SearchResultType
        : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("SearchResult");
            descriptor.Type<ObjectType<Starship>>();
            descriptor.Type<HumanType>();
            descriptor.Type<DroidType>();
        }
    }
}
