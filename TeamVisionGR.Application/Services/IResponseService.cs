using System.Net;

namespace TeamVisionGR.Application.Services
{
    public interface IResponseService
    {
        ResponseService AddError(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest);
        HttpStatusCode GetStatusCode();
        void SetStatusCode(HttpStatusCode statusCode);
    }
}