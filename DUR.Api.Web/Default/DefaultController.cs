using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace DUR.Api.Web.Default
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        protected string ComputeSha256Hash(string data)
        {
            SHA256 sha256hash = SHA256.Create();
            byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
