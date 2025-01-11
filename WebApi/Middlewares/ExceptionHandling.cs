using System.Net;
using Application.Exceptions;
using Application.Wrappers;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace WebApi.Middlewares
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _logger;
        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            var response = ApiResponse<string>.ErrorResponse(new List<string> { ex.Message });
            switch (ex)
            {
                case UnauthorizedAccessException _:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ProductException _:
                    code = HttpStatusCode.BadRequest;
                    response = new ApiResponse<string>(false, "", response.Message, response.Errors);
                    break;
                case ProductNotFoundException:
                case CategoryListotFoundException:
                case ProductListNotFoundException:
                    code = HttpStatusCode.NotFound;
                    response = new ApiResponse<string>(false,"", response.Message,response.Errors);
                    break;
                case InvalidOperationException _:
                    code = HttpStatusCode.BadRequest;
                    break;
                case DbUpdateException _:
                    code = HttpStatusCode.InternalServerError;
                    response = ApiResponse<string>.ErrorResponse(new List<string> { "There was a problem updating the database." });
                    break;
                default:
                    response = ApiResponse<string>.ErrorResponse(new List<string> { "An unexpected error occurred." });
                    break;
            }
            _logger.LogError(ex, "Unhandled exception occurred.");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, serializerSettings));
        }
    }
}
