namespace ApiNET.Services
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; } = default(T);
    }
}