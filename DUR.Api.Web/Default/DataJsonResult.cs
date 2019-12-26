using System.Collections.Generic;

namespace DUR.Api.Web.Default
{
    public class DataJsonResult<T> : InfoJsonResult where T : class
    {
        public IEnumerable<T> Data { get; set; }

        public DataJsonResult(int statusCode, string message, IEnumerable<T> data) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
