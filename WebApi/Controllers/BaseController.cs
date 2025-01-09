using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleDataResponse<T>(T data)
        {
            if (data == null)
            {
                return NotFound(new { Message = "Resource not found" });
            }

           return Ok( new ApiResponse<T>(true, "", data));
        }
    }
}
