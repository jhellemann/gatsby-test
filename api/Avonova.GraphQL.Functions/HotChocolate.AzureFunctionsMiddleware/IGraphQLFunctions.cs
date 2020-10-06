using System.Threading;
using System.Threading.Tasks;
using HotChocolate.Execution;
using HotChocolate.Language;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avonova.GraphQL.Functions.HotChocolate.AzureFunctionsMiddleware
{
    public interface IGraphQLFunctions
    {
        IAzureFunctionsMiddlewareOptions AzureFunctionsOptions { get; }
        IDocumentCache DocumentCache { get; }
        IDocumentHashProvider DocumentHashProvider { get; }
        IQueryExecutor Executor { get; }
        Task<IActionResult> ExecuteFunctionsQueryAsync(
            HttpContext context,
            CancellationToken cancellationToken);
    }
}