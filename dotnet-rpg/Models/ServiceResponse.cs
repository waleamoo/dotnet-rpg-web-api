namespace dotnet_rpg.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; } // the actual data we want to respond with
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
