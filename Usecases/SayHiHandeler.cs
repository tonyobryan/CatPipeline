using CatPipeline.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CatPipeline.Usecases
{
    public class SayHiHandeler : IRequestHandler<SayHiHandeler.Request, OkResponse>
    {
        public async Task<OkResponse> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new OkResponse { Message = $"Hello {request.Message}" });
        }

        public record Request(string Message) : IRequest<OkResponse>;
    }
}
