namespace Application.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public ApiResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }

        public ApiResponse(bool success, string message, T data, List<string> errors)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Request successful")
        {
            return new ApiResponse<T>(true, message, data);
        }

        public static ApiResponse<T> ErrorResponse(List<string> errors, string message = "An error occurred")
        {
            return new ApiResponse<T>(false, message, default(T), errors);
        }
    }

}
