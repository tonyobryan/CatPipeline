using CatPipeline.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CatPipeline.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : BaseResponse
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation($">>>>>>>>>>>> Handling {typeof(TRequest).Name} <<");
            var response = await next();
            logger.LogInformation($">>>>>>>>>>>> Handled {typeof(TRequest).Name} <<");
            logger.LogInformation($">>>>>>>>>>>> Result was {response.Message} <<");
            logger.LogInformation($">>>>>>>>>>>> With status {response.StatusCode} <<");
            return response;
        }
    }
}
