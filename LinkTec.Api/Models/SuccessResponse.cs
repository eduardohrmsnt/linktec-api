namespace LinkTec.Api.Models
{
    public class SuccessResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
