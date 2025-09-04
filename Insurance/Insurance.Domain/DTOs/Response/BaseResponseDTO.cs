namespace Insurance.Domain.DTOs.Response
{
    public class BaseResponseDTO
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public object? Data { get; set; } = null; 

        public Exception? Exception { get; set; } = null; 
    }
}
