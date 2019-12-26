namespace DUR.Api.Web.Default
{
    public class SingleDataJsonResult<T> : InfoJsonResult where T : class
    {
        public T Data { get; set; }

        public SingleDataJsonResult(int statusCode, string message, T data) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
