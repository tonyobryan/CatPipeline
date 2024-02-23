using CatPipeline.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CatPipeline.Usecases
{
    public class SayHiHandler : IRequestHandler<SayHiHandler.Request, OkResponse>
    {
        public async Task<OkResponse> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new OkResponse { Message = $"Hello {request.Message}" });
        }

        public record Request(string Message) : IRequest<OkResponse>;
    }
}
