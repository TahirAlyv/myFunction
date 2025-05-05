using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace myFunction
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("Function1")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
 
            string mail = req.Query["mail"];

            if (string.IsNullOrEmpty(mail))
            {
                return new BadRequestObjectResult("Please provide a 'mail' query parameter.");
            }
 
            string responseMessage = $"Hello {mail}, this message is from AzureFunction";

            return new OkObjectResult(responseMessage);
        }

        [Function("Function2")]
        public IActionResult Run2([HttpTrigger(AuthorizationLevel.Admin, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions! Admin LEVEL");
        }

        [Function("Function3")]
        public IActionResult Run3([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!Anonymous LEVEL");
        }
    }
}
