using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DUR.Api.Web.Default
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        
    }
}
