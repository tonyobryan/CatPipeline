using System.Net;

namespace CatPipeline.Response;
public class OkResponse : BaseResponse
{
    public OkResponse() : base(HttpStatusCode.OK)
    {
    }
}
