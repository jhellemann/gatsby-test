using HotChocolate.AspNetCore;

namespace Avonova.GraphQL.Functions.HotChocolate.AzureFunctionsMiddleware
{
    public interface IAzureFunctionsMiddlewareOptions
        : IParserOptionsAccessor
    {
        int MaxRequestSize { get; }
    }
}
