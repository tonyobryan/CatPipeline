using CatPipeline.Response;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CatPipeline.Behaviours
{
    public class ExceptionBehavior<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TResponse : BaseResponse, new ()
        where TException : Exception
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ExceptionBehavior<TRequest, TResponse, TException>> logger;

        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse, TException>> logger)
        {
            this.logger = logger;
        }

        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            TResponse response = new() { HasError = true, HttpStatusCode = HttpStatusCode.InternalServerError };

            if (exception is ValidationException vex)
            {
                response.Message = $"Validation failed: {string.Join(',', vex.Errors)}";
            }
            else
            {
                logger.LogError(exception, $"An unhandled exception occured: {exception.Message}");
                response.Message = "Inturnal Server Error, Please contact your administrator";
            }
            state.SetHandled(response);
            return Task.CompletedTask;
        }
    }
}
