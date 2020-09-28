using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Api
{
    public static class StarWarsFunction
    {
        [FunctionName("star-wars")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var data = new List<string>
            {
                "Episode I - The Phantom Menace",
                "Episode II - Attack of the Clones",
                "Episode III - Revenge of the Sith",
                "Episode IV - A New Hope",
                "Episode V - The Empire Strikes Back",
                "Episode VI - Return of the Jedi",
                "Episode VII - The Force Awakens",
                "Episode VIII - The Last Jedi",
                "Episode IX - The Rise of Skywalker"
            };

            return new OkObjectResult(data);
        }
    }
}
