using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

using TeamVisionGR.API.Filters;
using TeamVisionGR.Application.Services;

namespace TeamVisionGR.API.Controllers
{
    [CustomResponseFilter]
    [ApiController]
    [Authorize]
    public abstract class TeamVisionGRController : ControllerBase
    {
        protected internal IActionResult Response(ResponseService response) {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.GetStatusCode(),
                ContentTypes = new MediaTypeCollection { "application/json" }
            };
        }
    }
}