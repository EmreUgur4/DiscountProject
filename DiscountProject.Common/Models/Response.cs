namespace DiscountProject.Common.Models
{
    public class Response<T> where T : class, new()
    {
        public bool IsSuccessfull { get; private set; }
        public T Data { get; private set; }
        public string Error { get; private set; }

        public static Response<T> Success(T data)
        {
            return new Response<T> { Data = data, IsSuccessfull = true };
        }

        public static Response<T> Fail(string error)
        {
            return new Response<T> { Error = error, IsSuccessfull = false };
        }
    }
}
