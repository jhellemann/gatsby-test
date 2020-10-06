using Microsoft.Extensions.DependencyInjection;

namespace Avonova.GraphQL.Functions.HotChocolate.AzureFunctionsMiddleware
{
    public static class AzureFunctionsMiddlewareExtension
    {
        public static IServiceCollection AddAzureFunctionsGraphQL(
            this IServiceCollection serviceCollection,
            IAzureFunctionsMiddlewareOptions options)
        {
            serviceCollection.AddSingleton<IAzureFunctionsMiddlewareOptions>(options);

            serviceCollection.AddSingleton<IGraphQLFunctions, GraphQLFunctions>();

            return serviceCollection;
        }

        public static IServiceCollection AddAzureFunctionsGraphQL(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAzureFunctionsGraphQL(new AzureFunctionsMiddlewareOptions());

            return serviceCollection;
        }
    }
}
