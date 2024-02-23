using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using System.Threading.Tasks;

namespace CatPipeline.Response;

public class BaseResponse : IStatusCodeActionResult
{
    public BaseResponse(HttpStatusCode httpStatusCode)
    {
        HttpStatusCode = httpStatusCode;
    }

    public HttpStatusCode HttpStatusCode { get; set; }
    public bool HasError { get; set; }
    public string Message { get; set; } = null!;

    public int? StatusCode => (int)HttpStatusCode;

    public async Task ExecuteResultAsync(ActionContext context)
    {
        ObjectResult result = new(new { HasError, Message })
        {
            StatusCode = StatusCode
        };

        await result.ExecuteResultAsync(context);
    }
}