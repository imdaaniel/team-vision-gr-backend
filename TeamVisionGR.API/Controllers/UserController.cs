using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TeamVisionGR.Application.Services;

namespace TeamVisionGR.API.Controllers
{
    [Route("[controller]")]
    public class UserController : TeamVisionGRController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetUser()
        {
            string id = HttpContext.Items["UserId"] as string;
            var response = await _userService.GetUserByIdAsync(Guid.Parse(id));

            return Response(response);
        }
    }
}