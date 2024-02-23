using CatPipeline.Usecases;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CatPipeline
{
    public class Functions
    {
        private readonly IMediator mediator;

        public Functions(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [FunctionName("SayHi")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "sayhi/{catName}")] HttpRequest req,
            ILogger log, string catName, CancellationToken cancellationToken)
        {
            return await mediator.Send(new SayHiHandler.Request(catName), cancellationToken);
        }
    }
}
