using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CatPipeline.Usecases
{
    public class SayHiHandeler : IRequestHandler<SayHiHandeler.Request, IActionResult>
    {
        public async Task<IActionResult> Handle(Request request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new OkObjectResult($"Hello {request.Message}"));
        }

        public record Request(string Message) : IRequest<IActionResult>;
    }
}
