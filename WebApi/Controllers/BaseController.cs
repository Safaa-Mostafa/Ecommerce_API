using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(bool success, T data = default, string message = "")
        {
            var response = new ApiResponse<T>(success, message, data);

            return success ? Ok(response) : BadRequest(response);
        }
        protected IActionResult ApiNotFound(string message = "Resource not found")
        {
            return NotFound(new ApiResponse<string>(false, message, null));
        }
    }
}
