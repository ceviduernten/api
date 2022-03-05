using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Default;

[EnableCors("_myAllowSpecificOrigins")]
[Route("[controller]")]
[ApiController]
public class DefaultController : Controller
{
    protected string ComputeSha256Hash(string data)
    {
        var sha256hash = SHA256.Create();
        var bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(data));
        var builder = new StringBuilder();
        for (var i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));
        return builder.ToString();
    }
}