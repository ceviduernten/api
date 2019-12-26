namespace DUR.Api.Web.Default
{
    public class InfoJsonResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public InfoJsonResult(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
