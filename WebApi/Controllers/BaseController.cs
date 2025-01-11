using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Ok<T>(T data = default,string message= "Operation completed successfully.")
        {
            var response = new ApiResponse<T>(true,"Operation completed successfully.", data);

            return base.Ok(response);
        }
        protected IActionResult ApiNotFound(string message = "Resource not found")
        {
            return NotFound(new ApiResponse<string>(false, message, null));
        }
    }
}


