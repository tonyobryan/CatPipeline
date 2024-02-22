using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CatPipeline.Behaviours
{
    public class Tony<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TResponse : ObjectResult, new ()
        where TException : Exception
    {
        public Task Handle(TRequest request, TException exception, RequestExceptionHandlerState<TResponse> state, CancellationToken cancellationToken)
        {
            if(exception is ValidationException vex)
            {
                //return new ObjectResult(vex.Message)
                //{
                //    StatusCode = (int)HttpStatusCode.InternalServerError
                //};

                var response = new TResponse()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };

                state.SetHandled(response);
                
            }

            return Task.CompletedTask;
        }
    }
}
