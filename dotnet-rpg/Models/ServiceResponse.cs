namespace dotnet_rpg.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; } // the actual data we want to respond with
        public bool Successs { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
